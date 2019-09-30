using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderIdentity : Identity<int>
    {
        public static OrderIdentity Null = new OrderIdentity(0);

        public OrderIdentity(int id) : base(id)
        {
        }
    }
}
