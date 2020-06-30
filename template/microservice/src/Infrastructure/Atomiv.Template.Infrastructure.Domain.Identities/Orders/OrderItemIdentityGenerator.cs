using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class OrderItemIdentityGenerator : StringIdentityGenerator<OrderItemIdentity>
    {
        protected override OrderItemIdentity Create(string value)
        {
            return new OrderItemIdentity(value);
        }
    }
}
