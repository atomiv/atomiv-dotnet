using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Application.Orders.Queries;
using Optivem.Template.Core.Application.Orders.Queries.Repositories;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.Persistence.Records;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.Persistence.Repositories
{
    public class OrderReadRepository : Repository, IOrderReadRepository
    {
        public OrderReadRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<BrowseOrdersQueryResponse> QueryAsync(BrowseOrdersQuery query)
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .GetPage(query.Page, query.Size)
                .ToListAsync();

            var recordResponses = orderRecords
                .Select(GetOrderHeaderReadModel)
                .ToList();

            var totalRecords = await CountAsync();

            return new BrowseOrdersQueryResponse
            {
                Records = recordResponses,
                TotalRecords = totalRecords,
            };
        }

        public Task<FindOrderQueryResponse> QueryAsync(FindOrderQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<ListOrdersQueryResponse> QueryAsync(ListOrdersQuery query)
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .OrderBy(e => e.Id)
                .ToListAsync();

            var resultRecords = orderRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListOrdersQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
        }

        public Task<bool> ExistsAsync(Guid orderId)
        {
            return Context.Orders.AsNoTracking()
                .AnyAsync(e => e.Id == orderId);
        }

        public Task<long> CountAsync()
        {
            return Context.Orders.LongCountAsync();
        }

        private BrowseOrdersRecordQueryResponse GetOrderHeaderReadModel(OrderRecord record)
        {
            var totalPrice = record.OrderItems.Sum(e => e.UnitPrice * e.Quantity);

            return new BrowseOrdersRecordQueryResponse
            {
                Id = record.Id,
                CustomerId = record.CustomerId,
                OrderDate = record.OrderDate,
                OrderStatus = record.OrderStatusId,
                TotalPrice = totalPrice,
            };
        }

        private ListOrdersRecordQueryResponse GetIdNameResult(OrderRecord record)
        {
            var name = record.Id.ToString();

            return new ListOrdersRecordQueryResponse
            {
                Id = record.Id,
                Name = name,
            };
        }
    }
}
