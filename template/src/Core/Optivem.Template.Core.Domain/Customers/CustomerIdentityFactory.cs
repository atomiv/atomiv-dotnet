using Optivem.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerIdentityFactory : IIdentityFactory<CustomerIdentity, int>
    {
        public CustomerIdentity Create(int id)
        {
            return new CustomerIdentity(id);
        }
    }
}
