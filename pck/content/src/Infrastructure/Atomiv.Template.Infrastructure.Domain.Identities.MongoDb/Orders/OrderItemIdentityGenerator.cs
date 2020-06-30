using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Orders
{
    public class OrderItemIdentityGenerator : StringIdentityGenerator<OrderItemIdentity>
    {
        protected override OrderItemIdentity Create(string value)
        {
            return new OrderItemIdentity(value);
        }
    }
}
