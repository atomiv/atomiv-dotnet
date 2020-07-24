using Atomiv.Infrastructure.MongoDb;
using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Products;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Products
{
    public class ProductIdentityGenerator : IdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(Guid value)
        {
            return new ProductIdentity(value);
        }
    }
}
