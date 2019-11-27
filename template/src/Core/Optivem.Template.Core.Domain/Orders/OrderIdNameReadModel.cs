using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdNameReadModel : IdNameReadModel<int>
    {
        public OrderIdNameReadModel(int id, string name) : base(id, name)
        {
        }
    }
}
