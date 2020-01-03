using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Infrastructure.Persistence;
using Optivem.Template.Infrastructure.Persistence.Records;

namespace Optivem.Template.Core.Infrastructure.Persistence.QueryHandlers
{
    // TODO: VC: Make base class with AsNoTracking

    public class FindCustomerQueryHandler : Repository, IRequestHandler<FindCustomerQuery, FindCustomerQueryResponse>
    {
        public FindCustomerQueryHandler(DatabaseContext context) 
            : base(context)
        {
        }

        public async Task<FindCustomerQueryResponse> HandleAsync(FindCustomerQuery request)
        {
            var customerId = request.Id;

            var customerRecord = await Context.Customers.AsNoTracking()
                .Include(e => e.Orders)
                    .ThenInclude(e => e.OrderItems)
                        .ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(e => e.Id == customerId);

            if (customerRecord == null)
            {
                throw new NotFoundRequestException();
            }

            return GetCustomerDetailReadModel(customerRecord);
        }

        private FindCustomerQueryResponse GetCustomerDetailReadModel(CustomerRecord customerRecord)
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

            return new FindCustomerQueryResponse
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                OpenOrders = openOrders,
                LastOrderDate = lastOrderDate,
                TotalOrders = totalOrders,
                TotalOrderValue = totalOrderValue,
                TopProducts = topProducts,
            };
        }
    }
}