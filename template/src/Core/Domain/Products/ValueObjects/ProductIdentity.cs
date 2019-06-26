using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products.ValueObjects
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
