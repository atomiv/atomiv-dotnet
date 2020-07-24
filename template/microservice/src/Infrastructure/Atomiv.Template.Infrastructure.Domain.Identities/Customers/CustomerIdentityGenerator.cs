using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Customers;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class CustomerIdentityGenerator : GuidIdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(Guid value)
        {
            return new CustomerIdentity(value);
        }
    }
}
