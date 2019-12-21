using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductIdNameReadModel : IdNameReadModel<ProductIdentity>
    {
        public ProductIdNameReadModel(ProductIdentity id, string name) : base(id, name)
        {
        }
    }
}
