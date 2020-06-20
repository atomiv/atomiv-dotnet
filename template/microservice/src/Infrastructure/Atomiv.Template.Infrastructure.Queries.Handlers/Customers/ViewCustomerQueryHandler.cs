using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Core.Common.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Customers
{
    public class ViewCustomerQueryHandler : QueryHandler<ViewCustomerQuery, ViewCustomerQueryResponse>
    {
        public ViewCustomerQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<ViewCustomerQueryResponse> HandleAsync(ViewCustomerQuery request)
        {
            var customerId = request.Id;

            var customerRecord = await Context.Customers.AsNoTracking()
                .Include(e => e.Orders)
                    .ThenInclude(e => e.OrderItems)
                        .ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(e => e.Id == customerId);

            if (customerRecord == null)
            {
                throw new ExistenceException();
            }

            return GetFindCustomerQueryResponse(customerRecord);
        }

        private ViewCustomerQueryResponse GetFindCustomerQueryResponse(CustomerRecord customerRecord)
        {
            var id = customerRecord.Id;
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

            return new ViewCustomerQueryResponse
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
    }
}