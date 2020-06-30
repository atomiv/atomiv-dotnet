using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Linq;
using Atomiv.Template.Infrastructure.Domain.Persistence;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Products
{
    public class ProductReadonlyRepository : Repository, IProductReadonlyRepository
    {
        public ProductReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(ProductIdentity productId)
        {
            var productRecordId = productId.TryToGuid();

            if(productRecordId == null)
            {
                return Task.FromResult(false);
            }

            return Context.Products.AsNoTracking()
                .AnyAsync(e => e.Id == productRecordId);
        }

        public Task<long> CountAsync()
        {
            return Context.Products
                .LongCountAsync();
        }

        public async Task<IReadonlyProduct> FindReadonlyAsync(ProductIdentity productId)
        {
            var productRecordId = productId.TryToGuid();

            if(productRecordId == null)
            {
                return null;
            }

            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productRecordId);

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public async Task<IEnumerable<IReadonlyProduct>> FindReadonlyAsync(IEnumerable<ProductIdentity> productIds)
        {
            var productRecordIds = productIds
                .Select(e => e.TryToGuid())
                .Where(e => e != null)
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
