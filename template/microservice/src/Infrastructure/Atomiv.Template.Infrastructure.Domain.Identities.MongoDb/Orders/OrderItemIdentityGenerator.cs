using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Orders;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Orders
{
    public class OrderItemIdentityGenerator : GuidIdentityGenerator<OrderItemIdentity>
    {
        protected override OrderItemIdentity Create(Guid value)
        {
            return new OrderItemIdentity(value);
        }
    }
}
