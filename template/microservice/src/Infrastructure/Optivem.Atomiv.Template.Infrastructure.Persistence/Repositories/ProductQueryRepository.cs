using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Records;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.Repositories
{
    public class ProductQueryRepository : Repository, IProductQueryRepository
    {
        public ProductQueryRepository(DatabaseContext context) : base(context)
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

            var totalRecords = await Context.Products.LongCountAsync();

            return new BrowseProductsQueryResponse
            {
                Records = productHeaderReadModels,
                TotalRecords = totalRecords,
            };
        }

        public async Task<ViewProductQueryResponse> QueryAsync(ViewProductQuery query)
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

        public async Task<FilterProductsQueryResponse> QueryAsync(FilterProductsQuery query)
        {
            var productRecords = await Context.Products.AsNoTracking()
                .OrderBy(e => e.ProductCode)
                .ToListAsync();

            var resultRecords = productRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await Context.Products.LongCountAsync();

            return new FilterProductsQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
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

        private static ViewProductQueryResponse GetFindProductQueryResponse(ProductRecord productRecord)
        {
            return new ViewProductQueryResponse
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
