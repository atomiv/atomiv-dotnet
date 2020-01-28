using Optivem.Atomiv.Infrastructure.SequentialGuid;
using Optivem.Atomiv.Template.Core.Domain.Orders;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.IdentityGenerators
{
    public class OrderIdentityGenerator : IdentityGenerator<OrderIdentity>
    {
        protected override OrderIdentity Create(Guid guid)
        {
            return new OrderIdentity(guid);
        }
    }
}
