using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Orders
{
    public class OrderDetailIdentity : Identity<int>
    {
        public OrderDetailIdentity(int id) 
            : base(id)
        {
        }
    }
}
