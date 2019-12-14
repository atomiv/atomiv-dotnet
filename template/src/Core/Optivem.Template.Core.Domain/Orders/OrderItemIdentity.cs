using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderItemIdentity : Identity<Guid>
    {
        public static OrderItemIdentity New() => new OrderItemIdentity(Guid.NewGuid());

        public OrderItemIdentity(Guid value)
            : base(value)
        {
        }
    }
}