using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Customers
{
    public class BrowseCustomersQueryHandler : QueryHandler<BrowseCustomersQuery, BrowseCustomersQueryResponse>
    {
        public BrowseCustomersQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<BrowseCustomersQueryResponse> HandleAsync(BrowseCustomersQuery request)
        {
            var page = request.Page;
            var size = request.Size;

            var customerRecords = await Context.Customers.AsNoTracking()
                .GetPage(page, size)
                .ToListAsync();

            var responseRecords = customerRecords
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Customers.LongCountAsync();

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