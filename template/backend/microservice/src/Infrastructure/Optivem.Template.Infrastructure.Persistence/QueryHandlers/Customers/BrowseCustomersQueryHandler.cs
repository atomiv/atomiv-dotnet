using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Infrastructure.Persistence;
using Optivem.Template.Infrastructure.Persistence.Records;

namespace Optivem.Template.Core.Infrastructure.Persistence.QueryHandlers
{
    public class BrowseCustomersQueryHandler : Repository, IRequestHandler<BrowseCustomersQuery, BrowseCustomersQueryResponse>
    {
        public BrowseCustomersQueryHandler(DatabaseContext context) 
            : base(context)
        {
        }

        public async Task<BrowseCustomersQueryResponse> HandleAsync(BrowseCustomersQuery request)
        {
            var page = request.Page;
            var size = request.Size;

            var customerRecords = await Context.Customers.AsNoTracking()
                .GetPage(page, size)
                .ToListAsync();

            var customerHeaderReadModels = customerRecords
                .Select(GetCustomerHeaderReadModel)
                .ToList();

            var totalRecords = await Context.Customers.CountAsync();

            // TODO: VC: Move to utilities for computations

            var totalPagesDecimal = (decimal)totalRecords / size;
            var totalPages = (long)Math.Ceiling(totalPagesDecimal);

            return new BrowseCustomersQueryResponse
            {
                Records = customerHeaderReadModels,
                TotalRecords = totalRecords,
            };
        }

        private BrowseCustomersRecordResponse GetCustomerHeaderReadModel(CustomerRecord customerRecord)
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