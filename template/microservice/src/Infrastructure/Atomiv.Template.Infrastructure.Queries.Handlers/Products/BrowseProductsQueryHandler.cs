using Microsoft.EntityFrameworkCore;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Products
{
    public class BrowseProductsQueryHandler : QueryHandler<BrowseProductsQuery, BrowseProductsQueryResponse>
    {
        public BrowseProductsQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<BrowseProductsQueryResponse> HandleAsync(BrowseProductsQuery request)
        {
            var page = request.Page;
            var size = request.Size;

            var productRecords = await Context.Products.AsNoTracking()
                .GetPage(page, size)
                .ToListAsync();

            var productHeaderReadModels = productRecords
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Products.LongCountAsync();

            return new BrowseProductsQueryResponse
            {
                Records = productHeaderReadModels,
                TotalRecords = totalRecords,
            };
        }

        private static BrowseProductsRecordResponse GetResponse(ProductRecord productRecord)
        {
            return new BrowseProductsRecordResponse
            {
                Id = productRecord.Id.ToString(),
                Code = productRecord.ProductCode,
                Description = productRecord.ProductName,
                UnitPrice = productRecord.ListPrice,
                IsListed = productRecord.IsListed,
            };
        }
    }
}