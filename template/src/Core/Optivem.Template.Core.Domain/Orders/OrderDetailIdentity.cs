using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderDetailIdentity : Identity<int>
    {
        public static OrderDetailIdentity Null = new OrderDetailIdentity(0);

        public OrderDetailIdentity(int id) 
            : base(id)
        {
        }
    }
}
