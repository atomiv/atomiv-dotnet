using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Products
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
