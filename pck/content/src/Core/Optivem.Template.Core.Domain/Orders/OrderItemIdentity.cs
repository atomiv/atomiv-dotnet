using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderItemIdentity : Identity<int>
    {
        public static OrderItemIdentity New = new OrderItemIdentity(0);

        public OrderItemIdentity(int id)
            : base(id)
        {
        }
    }
}