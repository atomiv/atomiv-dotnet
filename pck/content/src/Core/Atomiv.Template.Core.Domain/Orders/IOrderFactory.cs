using Atomiv.Core.Domain;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Domain.Orders
{
    public interface IOrderFactory : IFactory
    {
        Order CreateOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderItems);

        OrderItem CreateOrderItem(ProductIdentity productId, decimal unitPrice, int quantity);
    }
}
