using Atomiv.Infrastructure.MongoDb;
using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Customers;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Customers
{
    public class CustomerIdentityGenerator : IdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(Guid value)
        {
            return new CustomerIdentity(value);
        }
    }
}
