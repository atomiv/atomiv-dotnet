using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IApplicationContext _applicationContext;

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerReadonlyRepository _customerReadonlyRepository;
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IOrderFactory _orderFactory;

        public CreateOrderCommandHandler(IApplicationContext applicationContext,
            IMapper mapper, 
            IOrderRepository orderRepository,
            ICustomerReadonlyRepository customerReadonlyRepository,
            IProductReadonlyRepository productReadonlyRepository,
            IOrderFactory orderFactory)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _customerReadonlyRepository = customerReadonlyRepository;
            _productReadonlyRepository = productReadonlyRepository;
            _orderFactory = orderFactory;
        }

        public async Task<CreateOrderCommandResponse> HandleAsync(CreateOrderCommand request)
        {
            var order = await GetOrderAsync(request);

            await _orderRepository.AddAsync(order);

            var response = _mapper.Map<Order, CreateOrderCommandResponse>(order);
            return response;
        }

        private async Task<Order> GetOrderAsync(CreateOrderCommand request)
        {
            var customerId = await GetCustomerIdAsync(request);
            var products = await GetProductsAsync(request);

            var orderItems = CreateOrderItems(request, products);
            var isPromotion = _applicationContext.IsPromotionDay;

            return _orderFactory.CreateOrder(customerId, orderItems);
        }

        private async Task<CustomerIdentity> GetCustomerIdAsync(CreateOrderCommand request)
        {
            var customerId = new CustomerIdentity(request.CustomerId);

            var existsCustomer = await _customerReadonlyRepository.ExistsAsync(customerId);

            if (!existsCustomer)
            {
                throw new ValidationException($"Customer {customerId} does not exist");
            }

            return customerId;
        }

        private async Task<IEnumerable<IReadonlyProduct>> GetProductsAsync(CreateOrderCommand request)
        {
            var productIds = request.OrderItems
                .Select(e => new ProductIdentity(e.ProductId))
                .Distinct()
                .ToList();

            var products = await _productReadonlyRepository.FindReadonlyAsync(productIds);

            if (productIds.Count != products.Count())
            {
                throw new ValidationException("Some products don't exist");
            }

            return products;
        }

        private IEnumerable<OrderItem> CreateOrderItems(CreateOrderCommand request, IEnumerable<IReadonlyProduct> products)
        {
            var orderItems = new List<OrderItem>();

            foreach (var createOrderItemRequest in request.OrderItems)
            {
                var orderDetail = GetOrderItem(createOrderItemRequest, products);
                orderItems.Add(orderDetail);
            }

            return orderItems;
        }

        private OrderItem GetOrderItem(CreateOrderItemCommand requestOrderDetail, IEnumerable<IReadonlyProduct> products)
        {
            var productId = new ProductIdentity(requestOrderDetail.ProductId);

            var product = products.Single(e => e.Id == productId);

            var unitPrice = product.ListPrice;
            var quantity = requestOrderDetail.Quantity;

            return _orderFactory.CreateOrderItem(productId, unitPrice, quantity);
        }
    }
}