using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderFactory
    {
        // TODO: VC: Consider IClock to be injected

        public static Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderDetails)
        {
            var id = OrderIdentity.New();
            return new Order(id, customerId, DateTime.Now, OrderStatus.New, orderDetails);
        }

        public static OrderItem CreateNewOrderDetail(Product product, decimal quantity)
        {
            if (product == null)
            {
                throw new ArgumentException();
            }

            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            // TODO: VC: Need to get the product price from repository, perhaps need customer mapper... or do it in the use case?
            // perhaps to be able to write a custom mapper...

            var id = OrderItemIdentity.New();

            return new OrderItem(id, product.Id, quantity, product.ListPrice, OrderItemStatus.Allocated);
        }
    }
}