using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Orders;
using System;

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
