using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Application.Products.Repositories;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderFactory _orderFactory;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(
            IOrderRepository orderRepository,
            IProductReadRepository productReadRepository,
            IOrderFactory orderFactory,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productReadRepository = productReadRepository;
            _orderFactory = orderFactory;
            _mapper = mapper;
        }

        public async Task<UpdateOrderCommandResponse> HandleAsync(UpdateOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            await UpdateAsync(order, request);

            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<Order, UpdateOrderCommandResponse>(order);
        }

        private async Task UpdateAsync(Order order, UpdateOrderCommand request)
        {
            var currentOrderDetails = order.OrderItems;

            var addedOrderRequestDetails = request.OrderItems.Where(e => e.Id == null).ToList();
            var updatedOrderRequestDetails = request.OrderItems.Where(e => e.Id != null).ToList();
            var deletedOrderDetails = order.OrderItems.Where(e => !request.OrderItems.Any(f => f.Id == e.Id)).ToList();

            foreach (var added in addedOrderRequestDetails)
            {
                var productPrice = await _productReadRepository.GetPriceAsync(added.ProductId);

                var productId = new ProductIdentity(added.ProductId);

                var orderItem = _orderFactory.CreateNewOrderItem(productId, productPrice.Value, added.Quantity);
                order.AddOrderItem(orderItem);
            }

            foreach (var updated in updatedOrderRequestDetails)
            {
                var orderItemId = new OrderItemIdentity(updated.Id.Value);
                var orderItem = order.OrderItems.First(e => e.Id == orderItemId);

                var productId = new ProductIdentity(updated.ProductId);

                var unitPrice = orderItem.UnitPrice;

                if(orderItem.ProductId != productId)
                {
                    var productPrice = await _productReadRepository.GetPriceAsync(updated.ProductId);
                    unitPrice = productPrice.Value;
                }

                order.UpdateOrderItem(orderItemId, productId, unitPrice, updated.Quantity);
            }

            foreach (var deleted in deletedOrderDetails)
            {
                order.RemoveOrderItem(deleted.Id);
            }
        }
    }
}