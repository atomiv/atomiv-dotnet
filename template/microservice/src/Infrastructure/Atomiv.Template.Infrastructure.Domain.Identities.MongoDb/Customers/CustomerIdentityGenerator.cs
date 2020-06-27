using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Customers
{
    public class CustomerIdentityGenerator : StringIdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(string value)
        {
            return new CustomerIdentity(value);
        }
    }
}
