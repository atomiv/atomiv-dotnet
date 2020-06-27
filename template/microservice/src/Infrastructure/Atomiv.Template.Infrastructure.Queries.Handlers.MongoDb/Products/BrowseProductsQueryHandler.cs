using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Products
{
    public class BrowseProductsQueryHandler : QueryHandler<BrowseProductsQuery, BrowseProductsQueryResponse>
    {
        public BrowseProductsQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override async Task<BrowseProductsQueryResponse> HandleAsync(BrowseProductsQuery request)
        {
            var productRecords = await Context.Products
                .Find(e => true)
                .GetPage(request.Page, request.Size)
                .ToListAsync();

            var productHeaderReadModels = productRecords
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Products
                .CountDocumentsAsync(e => true);

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
