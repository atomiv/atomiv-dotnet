using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class ProductIdentityGenerator : StringIdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(string value)
        {
            return new ProductIdentity(value);
        }
    }
}
