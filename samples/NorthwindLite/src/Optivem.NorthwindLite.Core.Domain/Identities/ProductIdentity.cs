using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Identities
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
