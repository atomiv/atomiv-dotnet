using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Identities
{
    public class OrderDetailIdentity : Identity<int>
    {
        public OrderDetailIdentity(int id) 
            : base(id)
        {
        }
    }
}
