using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderItemIdentityGenerator : IIdentityGenerator<OrderItemIdentity>
    {
        public OrderItemIdentity Next()
        {
            return new OrderItemIdentity(Guid.NewGuid());
        }
    }
}
