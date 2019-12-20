using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.Persistence.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.Persistence.Repositories
{
    public class ProductReadRepository : Repository, IProductReadRepository
    {
        public ProductReadRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(ProductIdentity productId)
        {
            var productRecordId = productId.Value;

            return Context.Products.AsNoTracking()
                .AnyAsync(e => e.Id == productRecordId);
        }

        public async Task<Product> FindAsync(ProductIdentity productId)
        {
            var productRecordId = productId.Value;

            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productRecordId);

            if (productRecord == null)
            {
                return null;
            }

            return GetProduct(productRecord);
        }

        public async Task<PageReadModel<ProductHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            var productRecords = await Context.Products.AsNoTracking()
                .Page(pageQuery)
                .ToListAsync();

            var productHeaderReadModels = productRecords
                .Select(GetProductHeaderReadModel)
                .ToList();

            var totalRecords = await CountAsync();

            return PageReadModel<ProductHeaderReadModel>.Create(pageQuery, productHeaderReadModels, totalRecords);
        }

        public async Task<ListReadModel<ProductIdNameReadModel>> ListAsync()
        {
            var productRecords = await Context.Products.AsNoTracking()
                .OrderBy(e => e.ProductCode)
                .ToListAsync();

            var resultRecords = productRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListReadModel<ProductIdNameReadModel>(resultRecords, totalRecords);
        }

        public Task<long> CountAsync()
        {
            return Context.Products.LongCountAsync();
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

        protected ProductHeaderReadModel GetProductHeaderReadModel(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id);
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductName;
            var listPrice = productRecord.ListPrice;
            var isListed = productRecord.IsListed;

            return new ProductHeaderReadModel(id, productCode, productName, listPrice, isListed);
        }

        protected ProductIdNameReadModel GetIdNameResult(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id);
            var name = $"{productRecord.ProductCode} - {productRecord.ProductName}";

            return new ProductIdNameReadModel(id, name);
        }

        #endregion
    }
}
