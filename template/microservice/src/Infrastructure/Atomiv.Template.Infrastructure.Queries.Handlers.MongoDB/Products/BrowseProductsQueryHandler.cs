using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Products
{
    public class BrowseProductsQueryHandler : QueryHandler<BrowseProductsQuery, BrowseProductsQueryResponse>
    {
        public BrowseProductsQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<BrowseProductsQueryResponse> HandleAsync(BrowseProductsQuery query)
        {
            var page = query.Page;
            var size = query.Size;

            var productRecords = await Context.Products
                .Find(e => true)
                .GetPage(page, size)
                .ToListAsync();

            var responseRecords = productRecords
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Products
                .CountDocumentsAsync(e => true);

            return new BrowseProductsQueryResponse
            {
                Records = responseRecords,
                TotalRecords = totalRecords,
            };
        }

        private static BrowseProductsRecordResponse GetResponse(ProductRecord productRecord)
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
