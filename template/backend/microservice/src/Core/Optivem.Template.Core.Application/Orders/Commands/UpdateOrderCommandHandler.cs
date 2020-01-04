using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Queries;
using Optivem.Template.Core.Application.Products.Repositories;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderFactory _orderFactory;

        public UpdateOrderCommandHandler(IMapper mapper, 
            IOrderRepository orderRepository, 
            IProductReadRepository productReadRepository,
            IOrderFactory orderFactory)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productReadRepository = productReadRepository;
            _orderFactory = orderFactory;
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

                if (productPrice == null)
                {
                    throw new ValidationException($"Product {added.ProductId} does not exist");
                }

                var productId = new ProductIdentity(added.ProductId);

                var orderDetail = _orderFactory.CreateNewOrderItem(productId, added.Quantity, productPrice.Value);
                order.AddOrderItem(orderDetail);
            }

            foreach (var updated in updatedOrderRequestDetails)
            {
                var orderDetailId = new OrderItemIdentity(updated.Id.Value);
                var orderDetail = order.OrderItems.First(e => e.Id == orderDetailId);

                var productPrice = await _productReadRepository.GetPriceAsync(updated.ProductId);

                if (productPrice == null)
                {
                    throw new ValidationException($"Product {updated.ProductId} does not exist");
                }

                var productId = new ProductIdentity(updated.ProductId);

                orderDetail.SetProduct(productId, productPrice.Value);
                orderDetail.Quantity = updated.Quantity;
            }

            foreach (var deleted in deletedOrderDetails)
            {
                order.RemoveOrderItem(deleted.Id);
            }
        }
    }
}