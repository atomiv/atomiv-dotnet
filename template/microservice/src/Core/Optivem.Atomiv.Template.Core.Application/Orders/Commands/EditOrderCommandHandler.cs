using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;
using Optivem.Atomiv.Template.Core.Domain.Orders;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Commands
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, EditOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IOrderFactory _orderFactory;
        private readonly IMapper _mapper;

        public EditOrderCommandHandler(
            IOrderRepository orderRepository,
            IProductReadonlyRepository productReadonlyRepository,
            IOrderFactory orderFactory,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productReadonlyRepository = productReadonlyRepository;
            _orderFactory = orderFactory;
            _mapper = mapper;
        }

        public async Task<EditOrderCommandResponse> HandleAsync(EditOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            await UpdateAsync(order, request);

            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<Order, EditOrderCommandResponse>(order);
        }

        private async Task UpdateAsync(Order order, EditOrderCommand request)
        {
            var currentOrderDetails = order.OrderItems;

            var addedOrderRequestDetails = request.OrderItems.Where(e => e.Id == null).ToList();
            var updatedOrderRequestDetails = request.OrderItems.Where(e => e.Id != null).ToList();
            var deletedOrderDetails = order.OrderItems.Where(e => !request.OrderItems.Any(f => f.Id == e.Id)).ToList();

            foreach (var added in addedOrderRequestDetails)
            {
                var productPrice = await _productReadonlyRepository.GetPriceAsync(added.ProductId);

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
                    var productPrice = await _productReadonlyRepository.GetPriceAsync(updated.ProductId);
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