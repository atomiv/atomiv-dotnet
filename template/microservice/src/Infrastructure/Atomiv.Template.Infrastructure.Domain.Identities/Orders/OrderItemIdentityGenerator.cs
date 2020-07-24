using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Orders;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class OrderItemIdentityGenerator : IdentityGenerator<OrderItemIdentity>
    {
        protected override OrderItemIdentity Create(Guid value)
        {
            return new OrderItemIdentity(value);
        }
    }
}
