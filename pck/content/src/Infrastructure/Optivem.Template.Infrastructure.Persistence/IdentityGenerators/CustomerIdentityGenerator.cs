using Optivem.Framework.Infrastructure.SequentialGuid;
using Optivem.Template.Core.Domain.Customers;
using System;

namespace Optivem.Template.Infrastructure.Persistence.IdentityGenerators
{
    public class CustomerIdentityGenerator : IdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(Guid guid)
        {
            return new CustomerIdentity(guid);
        }
    }
}
