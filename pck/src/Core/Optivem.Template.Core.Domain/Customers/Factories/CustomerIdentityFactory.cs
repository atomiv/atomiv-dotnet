using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Customers.Factories
{
    public class CustomerIdentityFactory : IIdentityFactory<CustomerIdentity, int>
    {
        public CustomerIdentity Create(int id)
        {
            return new CustomerIdentity(id);
        }
    }
}
