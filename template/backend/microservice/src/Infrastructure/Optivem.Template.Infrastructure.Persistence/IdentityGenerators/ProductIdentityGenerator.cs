using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.SequentialGuid;
using Optivem.Template.Core.Domain.Products;
using System;

namespace Optivem.Template.Infrastructure.Persistence.IdentityGenerators
{
    public class ProductIdentityGenerator : IdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(Guid guid)
        {
            return new ProductIdentity(guid);
        }
    }
}
