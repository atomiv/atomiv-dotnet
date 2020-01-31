using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Core.Common.Utilities;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;
using Optivem.Atomiv.Template.Core.Common.Orders;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Records;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.Repositories
{
    public class CustomerQueryRepository : Repository, ICustomerQueryRepository
    {
        public CustomerQueryRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<BrowseCustomersQueryResponse> QueryAsync(BrowseCustomersQuery query)
        {
            var page = query.Page;
            var size = query.Size;

            var customerRecords = await Context.Customers.AsNoTracking()
                .GetPage(page, size)
                .ToListAsync();

            var responseRecords = customerRecords
                .Select(GetBrowseCustomersQueryRecordResponse)
                .ToList();

            var totalRecords = await Context.Customers.CountAsync();

            // TODO: VC: Move to utilities for computations

            var totalPages = MathUtilities.GetTotalPages(totalRecords, size);

            return new BrowseCustomersQueryResponse
            {
                Records = responseRecords,
                TotalRecords = totalRecords,
            };
        }

        public async Task<FindCustomerQueryResponse> QueryAsync(FindCustomerQuery query)
        {
            var customerId = query.Id;

            var customerRecord = await Context.Customers.AsNoTracking()
                .Include(e => e.Orders)
                    .ThenInclude(e => e.OrderItems)
                        .ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(e => e.Id == customerId);

            if (customerRecord == null)
            {
                return null;
            }

            return GetFindCustomerQueryResponse(customerRecord);
        }

        public async Task<ListCustomersQueryResponse> QueryAsync(ListCustomersQuery query)
        {
            var nameSearch = query.NameSearch;
            var limit = query.Limit;

            var customerRecords = await Context.Customers.AsNoTracking()
                .Where(e => e.FirstName.Contains(nameSearch) || e.LastName.Contains(nameSearch))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Take(limit)
                .ToListAsync();

            var resultRecords = customerRecords
                .Select(GetListCustomersQueryResponse)
                .ToList();

            var totalRecords = await CountAsync();

            return new ListCustomersQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
        }


        public Task<bool> ExistsAsync(Guid customerId)
        {
            return Context.Customers.AsNoTracking()
                .AnyAsync(e => e.Id == customerId);
        }

        public Task<long> CountAsync()
        {
            return Context.Customers.LongCountAsync();
        }

        #region Helper

        private ListCustomersRecordResponse GetListCustomersQueryResponse(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var name = $"{customerRecord.FirstName} {customerRecord.LastName}";

            return new ListCustomersRecordResponse
            {
                Id = id,
                Name = name,
            };
        }

        private Customer GetCustomer(CustomerRecord customerRecord)
        {
            var identity = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            return new Customer(identity, firstName, lastName);
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

        private FindCustomerQueryResponse GetFindCustomerQueryResponse(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            var openOrders = customerRecord.Orders
                .Where(e => e.OrderStatusId != OrderStatus.Closed)
                .Count();

            var lastOrderDate = customerRecord.Orders
                .Max(e => (DateTime?)e.OrderDate);

            var totalOrders = customerRecord.Orders
                .Count;

            var totalOrderValue = customerRecord.Orders
                .SelectMany(e => e.OrderItems)
                .Select(e => e.UnitPrice * e.Quantity)
                .Sum(e => (decimal?)e)
                .GetValueOrDefault();

            var topProducts = customerRecord.Orders
                .SelectMany(e => e.OrderItems)
                .GroupBy(e => e.Product)
                .OrderByDescending(e => e.Count())
                .Select(e => e.Key.ProductName)
                .ToList();

            return new FindCustomerQueryResponse
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                OpenOrders = openOrders,
                LastOrderDate = lastOrderDate,
                TotalOrders = totalOrders,
                TotalOrderValue = totalOrderValue,
                TopProducts = topProducts
            };
        }



        #endregion
    }
}
