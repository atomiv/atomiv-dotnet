using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Domain.Customers.Factories
{
    public class CustomerIdentityFactory : IIdentityFactory<CustomerIdentity, int>
    {
        public CustomerIdentity Create(int id)
        {
            return new CustomerIdentity(id);
        }
    }
}
