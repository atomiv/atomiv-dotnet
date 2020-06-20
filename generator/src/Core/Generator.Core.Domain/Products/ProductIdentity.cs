using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Products
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
