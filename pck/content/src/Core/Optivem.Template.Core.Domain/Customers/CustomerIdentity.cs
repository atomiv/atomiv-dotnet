using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<Guid>
    {
        public static CustomerIdentity New() => new CustomerIdentity(Guid.NewGuid());

        public CustomerIdentity(Guid id) : base(id)
        {
        }
    }
}