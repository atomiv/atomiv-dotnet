using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class EditOrderCommandHandler : ICommandHandler<EditOrderCommand, EditOrderCommandResponse>
    {
        private readonly IOrderFactory _orderFactory;
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditOrderCommandHandler(IOrderFactory orderFactory,
            IProductReadonlyRepository productReadonlyRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productReadonlyRepository = productReadonlyRepository;
            _orderFactory = orderFactory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EditOrderCommandResponse> HandleAsync(EditOrderCommand command)
        {
            var orderId = new OrderIdentity(command.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if(order == null)
            {
                throw new ExistenceException();
            }

            await UpdateAsync(order, command);

            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Order, EditOrderCommandResponse>(order);
        }

        private async Task UpdateAsync(Order order, EditOrderCommand request)
        {
            var products = await GetProductsAsync(request);

            var addedOrderItemRequests = request.OrderItems
                .Where(e => e.Id == null)
                .ToList();

            var updatedOrderItemRequests = request.OrderItems
                .Where(e => e.Id != null)
                .ToList();

            var removedOrderItemIds = order.OrderItems
                .Where(e => !request.OrderItems.Any(f => f.Id == e.Id))
                .Select(e => e.Id)
                .ToList();

            AddOrderItems(order, products, addedOrderItemRequests);
            UpdateOrderItems(order, products, updatedOrderItemRequests);
            RemoveOrderItems(order, removedOrderItemIds);
        }

        private void AddOrderItems(Order order, 
            IEnumerable<IReadonlyProduct> products, 
            IEnumerable<EditOrderItemCommand> addedOrderItemRequests)
        {
            foreach (var orderItemRequest in addedOrderItemRequests)
            {
                var productId = new ProductIdentity(orderItemRequest.ProductId);
                var product = products.Single(e => e.Id == productId);
                var unitPrice = product.ListPrice;
                var quantity = orderItemRequest.Quantity;

                var orderItem = _orderFactory.CreateOrderItem(productId, unitPrice, quantity);

                order.AddOrderItem(orderItem);
            }
        }

        private void UpdateOrderItems(Order order,
            IEnumerable<IReadonlyProduct> products,
            IEnumerable<EditOrderItemCommand> updatedOrderItemRequests)
        {
            foreach (var orderItemRequest in updatedOrderItemRequests)
            {
                var orderItemId = new OrderItemIdentity(orderItemRequest.Id.Value);
                var orderItem = order.OrderItems.Single(e => e.Id == orderItemId);

                var productId = new ProductIdentity(orderItemRequest.ProductId);

                var unitPrice = orderItem.UnitPrice;

                if (orderItem.ProductId != productId)
                {
                    var product = products.Single(e => e.Id == productId);
                    unitPrice = product.ListPrice;
                }

                order.UpdateOrderItem(orderItemId, productId, unitPrice, orderItemRequest.Quantity);
            }
        }

        private void RemoveOrderItems(Order order, IEnumerable<OrderItemIdentity> removedOrderItemIds)
        {
            foreach (var orderItemId in removedOrderItemIds)
            {
                order.RemoveOrderItem(orderItemId);
            }
        }

        private async Task<IEnumerable<IReadonlyProduct>> GetProductsAsync(EditOrderCommand request)
        {
            var productIds = request.OrderItems
                .Select(e => new ProductIdentity(e.ProductId))
                .Distinct()
                .ToList();

            var products = await _productReadonlyRepository.FindReadonlyAsync(productIds);

            if(productIds.Count != products.Count())
            {
                throw new ValidationException("Some products don't exist");
            }

            return products;
        }
    }
}