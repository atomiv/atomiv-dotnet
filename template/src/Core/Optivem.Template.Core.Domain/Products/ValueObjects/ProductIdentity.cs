using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
