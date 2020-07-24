using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderIdentity : GuidIdentity
    {
        public OrderIdentity(Guid value) : base(value)
        {
        }
    }
}