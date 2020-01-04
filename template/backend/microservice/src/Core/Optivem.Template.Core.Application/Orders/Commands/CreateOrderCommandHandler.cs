using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Repositories;
using Optivem.Template.Core.Application.Products.Repositories;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderFactory _orderFactory;

        public CreateOrderCommandHandler(IMapper mapper, 
            IOrderRepository orderRepository, 
            ICustomerReadRepository customerReadRepository, 
            IProductReadRepository productReadRepository,
            IOrderFactory orderFactory)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _customerReadRepository = customerReadRepository;
            _productReadRepository = productReadRepository;
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
            var customerId = new CustomerIdentity(request.CustomerId);

            var customerExists = await _customerReadRepository.ExistsAsync(request.CustomerId);

            if (!customerExists)
            {
                throw new ValidationException($"Customer {request.CustomerId} does not exist");
            }

            var orderDetails = new List<OrderItem>();

            for (int i = 0; i < request.OrderItems.Count; i++)
            {
                var requestOrderDetail = request.OrderItems[i];

                try
                {
                    var orderDetail = await GetOrderItem(requestOrderDetail);
                    orderDetails.Add(orderDetail);
                }
                catch (ValidationException ex)
                {
                    var position = i + 1;
                    throw new ValidationException($"Order detail at position {position} is invalid", ex);
                }
            }

            return _orderFactory.CreateNewOrder(customerId, orderDetails);
        }

        private async Task<OrderItem> GetOrderItem(CreateOrderItemCommand requestOrderDetail)
        {
            var productPrice = await _productReadRepository.GetPriceAsync(requestOrderDetail.ProductId);

            if (productPrice == null)
            {
                throw new ValidationException($"Product id {requestOrderDetail.ProductId} is not valid because that product does not exist");
            }

            var productId = new ProductIdentity(requestOrderDetail.ProductId);

            var quantity = requestOrderDetail.Quantity;

            return _orderFactory.CreateNewOrderItem(productId, quantity, productPrice.Value);
        }
    }
}