using Optivem.Framework.Infrastructure.SequentialGuid;
using Optivem.Template.Core.Domain.Orders;
using System;

namespace Optivem.Template.Infrastructure.Persistence.IdentityGenerators
{
    public class OrderIdentityGenerator : IdentityGenerator<OrderIdentity>
    {
        protected override OrderIdentity Create(Guid guid)
        {
            return new OrderIdentity(guid);
        }
    }
}
