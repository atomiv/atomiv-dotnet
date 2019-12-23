using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.Persistence.Records;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : ProductReadRepository, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public void Add(Product product)
        {
            var productRecord = GetProductRecord(product);
            Context.Products.Add(productRecord);
        }

        public async Task UpdateAsync(Product product)
        {
            var productRecord = await Context.Products
                .FirstOrDefaultAsync(e => e.Id == product.Id);

            UpdateProductRecord(productRecord, product);

            try
            {
                Context.Products.Update(productRecord);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
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

        private ProductRecord GetProductRecord(ProductIdentity productId)
        {
            return new ProductRecord
            {
                Id = productId,
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