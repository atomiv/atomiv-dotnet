using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using Optivem.Atomiv.Template.Core.Domain.Orders;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IOrderFactory _orderFactory;

        public CreateOrderCommandHandler(IMapper mapper, 
            IOrderRepository orderRepository,
            IProductReadonlyRepository productReadonlyRepository,
            IOrderFactory orderFactory)
        {
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

            return _orderFactory.CreateNewOrder(customerId, orderDetails);
        }

        private async Task<OrderItem> GetOrderItem(CreateOrderItemCommand requestOrderDetail)
        {
            var productPrice = await _productReadonlyRepository.GetPriceAsync(requestOrderDetail.ProductId);

            var productId = new ProductIdentity(requestOrderDetail.ProductId);

            var quantity = requestOrderDetail.Quantity;

            return _orderFactory.CreateNewOrderItem(productId, productPrice.Value, quantity);
        }
    }
}