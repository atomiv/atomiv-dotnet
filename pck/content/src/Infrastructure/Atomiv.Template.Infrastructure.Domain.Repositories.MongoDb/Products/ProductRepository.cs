using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.Products
{
    public class ProductRepository : ProductReadonlyRepository, IProductRepository
    {
        public ProductRepository(MongoDbContext context) : base(context)
        {
        }

        public Task AddAsync(Product product)
        {
            var productRecord = GetProductRecord(product);

            return Context.Products.InsertOneAsync(productRecord);
        }

        public async Task<Product> FindAsync(ProductIdentity productId)
        {
            var productRecordId = productId.TryToObjectId();

            if(productRecordId == null)
            {
                return null;
            }

            var productRecord = await Context.Products
                .Find(e => e.Id == productRecordId)
                .FirstOrDefaultAsync();

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public Task SyncAsync(IEnumerable<Product> products)
        {
            // TODO: VC: Implement list differences

            var productRecords = products
                .Select(GetProductRecord)
                .ToList();

            return Context.Products
                .InsertManyAsync(productRecords);
        }

        public Task UpdateAsync(Product product)
        {
            var productRecordId = product.Id.ToObjectId();

            var filter = Builders<ProductRecord>.Filter
                .Eq(e => e.Id, productRecordId);

            var productRecord = GetProductRecord(product);

            return Context.Products.FindOneAndReplaceAsync(filter, productRecord);
        }

        #region Helper

        private ProductRecord GetProductRecord(Product product)
        {
            return new ProductRecord
            {
                Id = product.Id.ToObjectId(),
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ListPrice = product.ListPrice,
                IsListed = product.IsListed,
            };
        }

        #endregion
    }
}
