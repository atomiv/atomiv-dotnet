using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Customers
{
    public class BrowseCustomersQueryHandler : QueryHandler<BrowseCustomersQuery, BrowseCustomersQueryResponse>
    {
        public BrowseCustomersQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override async Task<BrowseCustomersQueryResponse> HandleAsync(BrowseCustomersQuery request)
        {
            var page = request.Page;
            var size = request.Size;

            var customerRecords = await Context.Customers
                .Find(e => true)
                .GetPage(page, size)
                .ToListAsync();

            var responseRecords = customerRecords
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Customers
                .CountDocumentsAsync(e => true);

            return new BrowseCustomersQueryResponse
            {
                Records = responseRecords,
                TotalRecords = totalRecords,
            };
        }

        private static BrowseCustomersRecordResponse GetResponse(CustomerRecord customerRecord)
        {
            return new BrowseCustomersRecordResponse
            {
                Id = customerRecord.Id,
                FirstName = customerRecord.FirstName,
                LastName = customerRecord.LastName,
            };
        }
    }
}
