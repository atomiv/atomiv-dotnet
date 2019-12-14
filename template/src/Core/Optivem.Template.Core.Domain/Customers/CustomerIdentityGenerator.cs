using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
