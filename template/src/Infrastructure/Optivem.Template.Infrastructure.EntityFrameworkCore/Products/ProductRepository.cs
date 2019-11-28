using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRepository : ProductReadRepository, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Product> AddAsync(Product product)
        {
            var productRecord = GetProductRecord(product);
            Context.Products.Add(productRecord);
            await Context.SaveChangesAsync();
            return GetProduct(productRecord);
        }

        public async Task RemoveAsync(ProductIdentity productId)
        {
            var productRecord = GetProductRecord(productId);
            Context.Remove(productRecord);
            await Context.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var productRecordId = product.Id.Id;
            var productRecord = await Context.Products.FindAsync(productRecordId);

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

            return GetProduct(productRecord);
        }

        #region Helper


        protected ProductRecord GetProductRecord(Product product)
        {
            var id = product.Id.Id;
            var productCode = product.ProductCode;
            var productName = product.ProductName;
            var listPrice = product.ListPrice;
            var isListed = product.IsListed;

            return new ProductRecord
            {
                Id = id,
                ProductCode = productCode,
                ProductName = productName,
                ListPrice = listPrice,
                IsListed = isListed,
            };
        }

        protected ProductRecord GetProductRecord(ProductIdentity productId)
        {
            return new ProductRecord
            {
                Id = productId.Id,
            };
        }

        protected void UpdateProductRecord(ProductRecord productRecord, Product product)
        {
            var id = product.Id.Id;
            var productCode = product.ProductCode;
            var productName = product.ProductName;
            var listPrice = product.ListPrice;
            var isListed = product.IsListed;

            productRecord.Id = id;
            productRecord.ProductCode = productCode;
            productRecord.ProductName = productName;
            productRecord.ListPrice = listPrice;
            productRecord.IsListed = isListed;
        }


        #endregion

        /*
         * 
        public async Task<Product> AddAsync(Product product)
        {

        }

        public async Task RemoveAsync(ProductIdentity productId)
        {

        }

        public async Task<Product> UpdateAsync(Product product)
        {

        }

         * 
         * 
         */
    }
}