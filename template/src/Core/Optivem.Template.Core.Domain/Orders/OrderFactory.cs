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
        // TODO: VC: Consider IClock to be injected

        private readonly IIdentityGenerator<OrderIdentity> _orderIdentityGenerator;
        private readonly IIdentityGenerator<OrderItemIdentity> _orderItemIdentityGenerator;

        public OrderFactory(IIdentityGenerator<OrderIdentity> orderIdentityGenerator, IIdentityGenerator<OrderItemIdentity> orderItemIdentityGenerator)
        {
            _orderIdentityGenerator = orderIdentityGenerator;
            _orderItemIdentityGenerator = orderItemIdentityGenerator;
        }

        public Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderDetails)
        {
            var id = _orderIdentityGenerator.Next();
            return new Order(id, customerId, DateTime.Now, OrderStatus.New, orderDetails);
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