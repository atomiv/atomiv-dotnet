using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerIdentityGenerator : IIdentityGenerator<CustomerIdentity>
    {
        public CustomerIdentity Next()
        {
            return new CustomerIdentity(Guid.NewGuid());
        }
    }
}
