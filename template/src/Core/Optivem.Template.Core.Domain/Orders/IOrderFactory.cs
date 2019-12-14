using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderFactory : IFactory
    {
        Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderDetails);

        OrderItem CreateNewOrderItem(Product product, decimal quantity);
    }
}
