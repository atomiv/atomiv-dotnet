using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderItemIdentity : GuidIdentity
    {
        public OrderItemIdentity(Guid value)
            : base(value)
        {
        }
    }
}