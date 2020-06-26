using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IApplicationContext _applicationContext;

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IOrderFactory _orderFactory;

        public CreateOrderCommandHandler(IApplicationContext applicationContext,
            IMapper mapper, 
            IOrderRepository orderRepository,
            IProductReadonlyRepository productReadonlyRepository,
            IOrderFactory orderFactory)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
            _orderRepository = orderRepository;
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
            var customerId = new CustomerIdentity(request.CustomerId);

            var orderDetails = new List<OrderItem>();

            foreach(var createOrderItemRequest in request.OrderItems)
            {
                var orderDetail = await GetOrderItem(createOrderItemRequest);
                orderDetails.Add(orderDetail);
            }

            var isPromotion = _applicationContext.IsPromotionDay;

            return _orderFactory.CreateOrder(customerId, orderDetails);
        }

        private async Task<OrderItem> GetOrderItem(CreateOrderItemCommand requestOrderDetail)
        {
            var productPrice = await _productReadonlyRepository.GetPriceAsync(requestOrderDetail.ProductId);

            var productId = new ProductIdentity(requestOrderDetail.ProductId);

            var quantity = requestOrderDetail.Quantity;

            return _orderFactory.CreateOrderItem(productId, productPrice.Value, quantity);
        }
    }
}