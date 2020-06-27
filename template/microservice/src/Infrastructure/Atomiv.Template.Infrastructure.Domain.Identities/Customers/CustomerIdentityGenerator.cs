using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class CustomerIdentityGenerator : IdentityGenerator<CustomerIdentity>
    {
        protected override CustomerIdentity Create(string value)
        {
            return new CustomerIdentity(value);
        }
    }
}
