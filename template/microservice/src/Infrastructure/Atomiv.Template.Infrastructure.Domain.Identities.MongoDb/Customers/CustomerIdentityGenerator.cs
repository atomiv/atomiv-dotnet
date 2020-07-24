using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Customers;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Customers
{
    public class CustomerIdentityGenerator : GuidIdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(Guid value)
        {
            return new CustomerIdentity(value);
        }
    }
}
