using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerIdNameReadModel : IdNameReadModel<int>
    {
        public CustomerIdNameReadModel(int id, string name) : base(id, name)
        {
        }
    }
}
