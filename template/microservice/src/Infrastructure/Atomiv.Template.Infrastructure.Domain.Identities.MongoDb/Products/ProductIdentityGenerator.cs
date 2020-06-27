using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Products
{
    public class ProductIdentityGenerator : StringIdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(string value)
        {
            return new ProductIdentity(value);
        }
    }
}
