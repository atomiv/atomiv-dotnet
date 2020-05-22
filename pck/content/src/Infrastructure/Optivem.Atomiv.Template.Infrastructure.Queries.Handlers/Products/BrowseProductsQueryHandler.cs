using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Application.Queries.Products;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Queries.Handlers.Products
{
    public class BrowseProductsQueryHandler : QueryHandler<BrowseProductsQuery, BrowseProductsQueryResponse>
    {
        public BrowseProductsQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<BrowseProductsQueryResponse> HandleAsync(BrowseProductsQuery request)
        {
            var productRecords = await Context.Products.AsNoTracking()
                .GetPage(request.Page, request.Size)
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
    }
}