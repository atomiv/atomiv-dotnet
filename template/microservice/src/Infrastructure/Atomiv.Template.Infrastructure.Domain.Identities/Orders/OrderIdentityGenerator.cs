using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class OrderIdentityGenerator : IdentityGenerator<OrderIdentity>
    {
        protected override OrderIdentity Create(string value)
        {
            return new OrderIdentity(value);
        }
    }
}
