using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Core.Common.Utilities;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Application.Queries.Customers;
using Optivem.Atomiv.Template.Core.Common.Orders;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common.Records;

namespace Optivem.Atomiv.Template.Infrastructure.Queries.Handlers.Customers
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
                .Select(GetBrowseCustomersQueryRecordResponse)
                .ToList();

            var totalRecords = await Context.Customers.CountAsync();

            var totalPages = MathUtilities.GetTotalPages(totalRecords, size);

            return new BrowseCustomersQueryResponse
            {
                Records = responseRecords,
                TotalRecords = totalRecords,
            };
        }

        private static BrowseCustomersRecordResponse GetBrowseCustomersQueryRecordResponse(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            var openOrders = customerRecord.Orders
                .Where(e => e.OrderStatusId != OrderStatus.Closed)
                .Count();

            return new BrowseCustomersRecordResponse
            {
                Id = customerRecord.Id,
                FirstName = customerRecord.FirstName,
                LastName = customerRecord.LastName,
            };
        }
    }
}