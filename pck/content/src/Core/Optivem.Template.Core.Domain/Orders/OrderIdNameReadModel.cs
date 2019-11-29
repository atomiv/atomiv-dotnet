using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdNameReadModel : IdNameReadModel<OrderIdentity>
    {
        public OrderIdNameReadModel(OrderIdentity id, string name) : base(id, name)
        {
        }
    }
}
