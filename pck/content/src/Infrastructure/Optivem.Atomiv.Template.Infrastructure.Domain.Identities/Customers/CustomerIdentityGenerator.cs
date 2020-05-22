using Optivem.Atomiv.Infrastructure.SequentialGuid;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.IdentityGenerators
{
    public class CustomerIdentityGenerator : IdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(Guid guid)
        {
            return new CustomerIdentity(guid);
        }
    }
}
