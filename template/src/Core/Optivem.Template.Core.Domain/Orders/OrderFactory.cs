using Optivem.Framework.Core.Common.Time;
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
        private readonly IClock _clock;

        public OrderFactory(IIdentityGenerator<OrderIdentity> orderIdentityGenerator, 
            IIdentityGenerator<OrderItemIdentity> orderItemIdentityGenerator,
            IClock clock)
        {
            _orderIdentityGenerator = orderIdentityGenerator;
            _orderItemIdentityGenerator = orderItemIdentityGenerator;
            _clock = clock;
        }

        public Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderDetails)
        {
            var id = _orderIdentityGenerator.Next();
            var orderDate = _clock.Now;
            return new Order(id, customerId, orderDate, OrderStatus.New, orderDetails);
        }

        public OrderItem CreateNewOrderItem(Product product, decimal quantity)
        {
            if (product == null)
            {
                throw new ArgumentException();
            }

            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            var id = _orderItemIdentityGenerator.Next();

            return new OrderItem(id, product.Id, quantity, product.ListPrice, OrderItemStatus.Allocated);
        }
    }
}