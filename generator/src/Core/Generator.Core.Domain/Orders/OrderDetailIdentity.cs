using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Orders
{
    public class OrderDetailIdentity : Identity<int>
    {
        public OrderDetailIdentity(int id) 
            : base(id)
        {
        }
    }
}
