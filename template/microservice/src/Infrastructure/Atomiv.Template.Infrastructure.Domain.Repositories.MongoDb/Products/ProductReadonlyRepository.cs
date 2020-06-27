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

        public async Task<bool> ExistsAsync(ProductIdentity productId)
        {
            var productRecordCursor = await Context.Products
                .FindAsync(e => e.Id == productId);

            var exists = await productRecordCursor
                .AnyAsync();

            return exists;
        }

        public async Task<IReadonlyProduct> FindReadonlyAsync(ProductIdentity productId)
        {
            var productRecordCursor = await Context.Products
                .FindAsync(e => e.Id == productId);

            var productRecord = await productRecordCursor
                .FirstOrDefaultAsync();

            if(productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public async Task<IEnumerable<IReadonlyProduct>> FindReadonlyAsync(IEnumerable<ProductIdentity> productIds)
        {
            var productRecordIds = productIds
                .Select(e => e.Value)
                .ToList();

            // TODO: VC: DELETE

            /*
            var filter = Builders<ProductRecord>.Filter
                .In(e => e.Id, productRecordIds);

            var productRecordCursor = await Context.Products
                .FindAsync(filter);

            */

            var productRecordCursor = await Context.Products
                .FindAsync(e => productRecordIds.Contains(e.Id));

            var productRecords = await productRecordCursor.ToListAsync();

            var products = productRecords
                .Select(GetProduct)
                .ToList();

            return products;
        }

        #region Helper

        protected Product GetProduct(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id);
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductName;
            var listPrice = productRecord.ListPrice;
            var isListed = productRecord.IsListed;

            return new Product(id, productCode, productName, listPrice, isListed);
        }

        #endregion
    }
}
