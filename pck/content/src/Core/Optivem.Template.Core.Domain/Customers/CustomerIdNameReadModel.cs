using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerIdNameReadModel : IdNameReadModel<CustomerIdentity>
    {
        public CustomerIdNameReadModel(CustomerIdentity id, string name) : base(id, name)
        {
        }
    }
}
