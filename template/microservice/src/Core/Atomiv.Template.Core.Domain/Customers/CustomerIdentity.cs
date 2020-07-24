using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerIdentity : GuidIdentity
    {
        public CustomerIdentity(Guid value) : base(value)
        {
        }
    }
}