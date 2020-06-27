using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using System;
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
            throw new NotImplementedException();

            /*
            var productRecordCursor = await Context.Products
                .FindAsync(e => e.Id == productId);

            var productRecord = await productRecordCursor.FirstOrDefaultAsync();

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
            */
        }

        public Task SyncAsync(IEnumerable<Product> products)
        {
            // TODO: VC: Implement list differences

            var productRecords = products
                .Select(GetProductRecord)
                .ToList();

            return Context.Products.InsertManyAsync(productRecords);
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        #region Helper

        private ProductRecord GetProductRecord(Product product)
        {
            return new ProductRecord
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ListPrice = product.ListPrice,
                IsListed = product.IsListed,
            };
        }

        private void UpdateProductRecord(ProductRecord productRecord, Product product)
        {
            productRecord.Id = product.Id;
            productRecord.ProductCode = product.ProductCode;
            productRecord.ProductName = product.ProductName;
            productRecord.ListPrice = product.ListPrice;
            productRecord.IsListed = product.IsListed;
        }

        #endregion
    }
}
