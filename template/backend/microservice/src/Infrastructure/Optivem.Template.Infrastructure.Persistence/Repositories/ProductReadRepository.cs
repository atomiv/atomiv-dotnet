using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Application.Products.Queries;
using Optivem.Template.Core.Application.Products.Repositories;
using Optivem.Template.Infrastructure.Persistence.Records;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.Persistence.Repositories
{
    public class ProductReadRepository : Repository, IProductReadRepository
    {
        public ProductReadRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<BrowseProductsQueryResponse> QueryAsync(BrowseProductsQuery query)
        {
            var productRecords = await Context.Products.AsNoTracking()
                .GetPage(query.Page, query.Size)
                .ToListAsync();

            var productHeaderReadModels = productRecords
                .Select(GetProductHeaderReadModel)
                .ToList();

            var totalRecords = await CountAsync();

            return new BrowseProductsQueryResponse
            {
                Records = productHeaderReadModels,
                TotalRecords = totalRecords,
            };
        }

        public async Task<FindProductQueryResponse> QueryAsync(FindProductQuery query)
        {
            var productId = query.Id;

            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productId);

            if (productRecord == null)
            {
                return null;
            }

            return GetFindProductQueryResponse(productRecord);
        }

        public async Task<ListProductsQueryResponse> QueryAsync(ListProductsQuery query)
        {
            var productRecords = await Context.Products.AsNoTracking()
                .OrderBy(e => e.ProductCode)
                .ToListAsync();

            var resultRecords = productRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListProductsQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
        }

        public Task<bool> ExistsAsync(Guid productId)
        {
            return Context.Products.AsNoTracking()
                .AnyAsync(e => e.Id == productId);
        }

        public Task<long> CountAsync()
        {
            return Context.Products.LongCountAsync();
        }

        public async Task<decimal?> GetPriceAsync(Guid productId)
        {
            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productId);

            if(productRecord == null)
            {
                return null;
            }

            return productRecord.ListPrice;
        }

        #region Helper

        private static BrowseProductsRecordResponse GetProductHeaderReadModel(ProductRecord productRecord)
        {
            return new BrowseProductsRecordResponse
            {
                Id = productRecord.Id,
                Code = productRecord.ProductCode,
                Description = productRecord.ProductName,
                UnitPrice = productRecord.ListPrice,
                IsListed = productRecord.IsListed,
            };
        }

        private static ListProductsRecordQueryResponse GetIdNameResult(ProductRecord productRecord)
        {
            var name = $"{productRecord.ProductCode} - {productRecord.ProductName}";

            return new ListProductsRecordQueryResponse
            {
                Id = productRecord.Id,
                Name = name,
            };
        }

        private static FindProductQueryResponse GetFindProductQueryResponse(ProductRecord productRecord)
        {
            return new FindProductQueryResponse
            {
                Id = productRecord.Id,
                Code = productRecord.ProductCode,
                Description = productRecord.ProductName,
                UnitPrice = productRecord.ListPrice,
                IsListed = productRecord.IsListed,
            };
        }

        #endregion
    }
}
