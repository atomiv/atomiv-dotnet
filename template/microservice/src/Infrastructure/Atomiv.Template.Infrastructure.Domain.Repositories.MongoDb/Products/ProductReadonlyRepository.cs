using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.Products
{
    public class ProductReadonlyRepository : Repository, IProductReadonlyRepository
    {
        public ProductReadonlyRepository(MongoDbContext context) : base(context)
        {
        }

        public Task<long> CountAsync()
        {
            return Context.Products
                .CountDocumentsAsync(e => true);
        }

        public Task<bool> ExistsAsync(ProductIdentity productId)
        {
            var productRecordId = productId.TryToObjectId();

            if(productRecordId == null)
            {
                return Task.FromResult(false);
            }

            return Context.Products
                .Find(e => e.Id == productRecordId)
                .AnyAsync();
        }

        public async Task<IReadonlyProduct> FindReadonlyAsync(ProductIdentity productId)
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

        public async Task<IEnumerable<IReadonlyProduct>> FindReadonlyAsync(IEnumerable<ProductIdentity> productIds)
        {
            var productRecordIds = productIds
                .Select(e => e.Value.TryToObjectId())
                .Where(e => e != null)
                .ToList();

            var productRecords = await Context.Products
                .Find(e => productRecordIds.Contains(e.Id))
                .ToListAsync();

            var products = productRecords
                .Select(GetProduct)
                .ToList();

            return products;
        }

        #region Helper

        protected Product GetProduct(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id.ToString());
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductName;
            var listPrice = productRecord.ListPrice;
            var isListed = productRecord.IsListed;

            return new Product(id, productCode, productName, listPrice, isListed);
        }

        #endregion
    }
}
