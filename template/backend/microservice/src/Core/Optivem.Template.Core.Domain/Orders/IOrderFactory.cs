using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderFactory : IFactory
    {
        Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderItems);

        OrderItem CreateNewOrderItem(ProductIdentity productId, decimal quantity, decimal listPrice);
    }
}
