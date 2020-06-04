using Optivem.Atomiv.Infrastructure.SequentialGuid;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class ProductIdentityGenerator : IdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(Guid guid)
        {
            return new ProductIdentity(guid);
        }
    }
}
