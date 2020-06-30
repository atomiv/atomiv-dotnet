using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Orders
{
    public class OrderIdentityGenerator : StringIdentityGenerator<OrderIdentity>
    {
        protected override OrderIdentity Create(string value)
        {
            return new OrderIdentity(value);
        }
    }
}
