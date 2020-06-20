using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Orders
{
    public class OrderIdentity : Identity<int>
    {
        public OrderIdentity(int id) : base(id)
        {
        }
    }
}
