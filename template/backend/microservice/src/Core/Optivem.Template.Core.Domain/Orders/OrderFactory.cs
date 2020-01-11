using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IIdentityGenerator<OrderIdentity> _orderIdentityGenerator;
        private readonly IIdentityGenerator<OrderItemIdentity> _orderItemIdentityGenerator;
        private readonly ITimeService _timeService;

        public OrderFactory(IIdentityGenerator<OrderIdentity> orderIdentityGenerator, 
            IIdentityGenerator<OrderItemIdentity> orderItemIdentityGenerator,
            ITimeService timeService)
        {
            _orderIdentityGenerator = orderIdentityGenerator;
            _orderItemIdentityGenerator = orderItemIdentityGenerator;
            _timeService = timeService;
        }

        public Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderItems)
        {
            var id = _orderIdentityGenerator.Next();
            var orderDate = _timeService.Now;
            return new Order(id, customerId, orderDate, OrderStatus.New, orderItems);
        }

        public OrderItem CreateNewOrderItem(ProductIdentity productId, decimal quantity, decimal listPrice)
        {
            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            var id = _orderItemIdentityGenerator.Next();

            return new OrderItem(id, productId, quantity, listPrice, OrderItemStatus.Allocated);
        }
    }
}