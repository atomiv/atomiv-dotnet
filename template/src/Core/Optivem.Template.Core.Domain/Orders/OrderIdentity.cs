using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdentity : Identity<int>
    {
        public OrderIdentity(int id) : base(id)
        {
        }
    }
}
