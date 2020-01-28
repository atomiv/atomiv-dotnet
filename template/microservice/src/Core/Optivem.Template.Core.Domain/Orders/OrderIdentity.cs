using Optivem.Atomiv.Core.Domain;
using System;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdentity : Identity<Guid>
    {
        public OrderIdentity(Guid value) : base(value)
        {
        }
    }
}