using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Products
{
    public class ProductRepository : ProductReadonlyRepository, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public Task AddAsync(Product product)
        {
            var productRecord = GetProductRecord(product);
            Context.Products.Add(productRecord);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
        {
            var productRecord = await Context.Products
                .FirstOrDefaultAsync(e => e.Id == product.Id);

            UpdateProductRecord(productRecord, product);

            Context.Products.Update(productRecord);
        }

        public async Task<Product> FindAsync(ProductIdentity productId)
        {
            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productId);

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public async Task<Product> FindAsync(string productCode)
        {
            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.ProductCode == productCode);

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public Task SyncAsync(IEnumerable<Product> products)
        {
            // TODO: VC: Implement list differences

            var addedProducts = products.Where(e => e.IsNew);
            var updatedProducts = products.Where(e => !e.IsNew);

            var addedProductRecords = addedProducts.Select(GetProductRecord).ToList();
            var updatedProductRecords = updatedProducts.Select(GetProductRecord).ToList();

            Context.Products.AddRange(addedProductRecords);
            Context.Products.UpdateRange(updatedProductRecords);

            return Task.CompletedTask;
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