using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderItemIdentity : Identity<Guid>
    {
        public OrderItemIdentity(Guid value)
            : base(value)
        {
        }
    }
}