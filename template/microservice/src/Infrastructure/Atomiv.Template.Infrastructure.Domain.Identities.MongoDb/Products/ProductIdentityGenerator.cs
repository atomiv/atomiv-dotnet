using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Products;
using MongoDB.Bson;

namespace Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.Products
{
    public class ProductIdentityGenerator : IdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(ObjectId value)
        {
            var valueStr = value.ToString();
            return new ProductIdentity(valueStr);
        }
    }
}
