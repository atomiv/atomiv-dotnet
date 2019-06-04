using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Identities
{
    public class OrderIdentity : Identity<int>
    {
        public OrderIdentity(int id) : base(id)
        {
        }
    }
}
