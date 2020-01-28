using Optivem.Atomiv.Core.Domain;
using System;

namespace Optivem.Atomiv.Template.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<Guid>
    {
        public CustomerIdentity(Guid value) : base(value)
        {
        }
    }
}