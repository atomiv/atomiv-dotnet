using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products.Entities;
using Optivem.Template.Core.Domain.Products.Repositories;
using Optivem.Template.Core.Domain.Products.ValueObjects;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Records;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Repositories
{
    public class ProductRepository : Repository<DatabaseContext, Product, ProductIdentity, ProductRecord, int>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        protected override Product GetAggregateRoot(ProductRecord record)
        {
            var identity = GetIdentity(record);
            return new Product(identity, record.ProductCode, record.ProductName, record.ListPrice);
        }

        protected override ProductIdentity GetIdentity(ProductRecord record)
        {
            var id = record.Id;
            return new ProductIdentity(id);
        }

        // TODO: VC: This method is only needed when there is deletion

        protected override ProductRecord GetRecord(ProductIdentity identity)
        {
            return new ProductRecord
            {
                Id = identity.Id,
            };
        }

        protected override ProductRecord GetRecord(Product aggregateRoot)
        {
            return new ProductRecord
            {
                Id = aggregateRoot.Id.Id,
                ProductCode = aggregateRoot.ProductCode,
                ProductName = aggregateRoot.ProductName,
                ListPrice = aggregateRoot.ListPrice,
            };
        }
    }
}
