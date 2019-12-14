using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<Guid>
    {
        public CustomerIdentity(Guid value) : base(value)
        {
        }
    }
}