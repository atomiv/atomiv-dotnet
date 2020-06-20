using Atomiv.Core.Domain;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Domain.Orders
{
    public interface IOrderFactory : IFactory
    {
        Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderItems);

        OrderItem CreateNewOrderItem(ProductIdentity productId, decimal unitPrice, int quantity);
    }
}
