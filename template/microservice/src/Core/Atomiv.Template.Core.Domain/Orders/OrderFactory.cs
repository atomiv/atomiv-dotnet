using Atomiv.Core.Domain;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IIdentityGenerator<OrderIdentity> _orderIdentityGenerator;
        private readonly IIdentityGenerator<OrderItemIdentity> _orderItemIdentityGenerator;
        private readonly ITimeService _timeService;

        private const OrderStatus CreatedOrderStatus = OrderStatus.Draft;
        private const OrderItemStatus CreatedOrderItemStatus = OrderItemStatus.Pending;

        public OrderFactory(IIdentityGenerator<OrderIdentity> orderIdentityGenerator, 
            IIdentityGenerator<OrderItemIdentity> orderItemIdentityGenerator,
            ITimeService timeService)
        {
            _orderIdentityGenerator = orderIdentityGenerator;
            _orderItemIdentityGenerator = orderItemIdentityGenerator;
            _timeService = timeService;
        }

        public Order CreateOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderItems)
        {
            var id = _orderIdentityGenerator.Next();
            var orderDate = _timeService.Now;
            return new Order(id, customerId, orderDate, CreatedOrderStatus, orderItems);
        }

        public OrderItem CreateOrderItem(ProductIdentity productId, decimal unitPrice, int quantity)
        {
            var id = _orderItemIdentityGenerator.Next();

            return new OrderItem(id, productId, unitPrice, quantity, CreatedOrderItemStatus);
        }
    }
}