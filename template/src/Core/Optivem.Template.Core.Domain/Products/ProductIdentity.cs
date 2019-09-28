using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductIdentity : Identity<int>
    {
        public static ProductIdentity Null = new ProductIdentity(0);

        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
