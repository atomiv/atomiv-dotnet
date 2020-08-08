using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Linq;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Products
{
    public class ProductReadonlyRepository : Repository, IProductReadonlyRepository
    {
        public ProductReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(ProductIdentity productId)
        {
            return Context.Products.AsNoTracking()
                .AnyAsync(e => e.Id == productId);
        }

        public Task<bool> ExistsAsync(string productCode)
        {
            return Context.Products.AsNoTracking()
                .AnyAsync(e => e.ProductCode == productCode);
        }

        public Task<long> CountAsync()
        {
            return Context.Products
                .LongCountAsync();
        }

        public async Task<IReadonlyProduct> FindReadonlyAsync(ProductIdentity productId)
        {
            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productId);

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }


        public async Task<IReadonlyProduct> FindReadonlyAsync(string productCode)
        {
            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.ProductCode == productCode);

            if (productRecord == null)
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

            var productRecords = await Context.Products.AsNoTracking()
                .Where(e => productRecordIds.Contains(e.Id))
                .ToListAsync();

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
