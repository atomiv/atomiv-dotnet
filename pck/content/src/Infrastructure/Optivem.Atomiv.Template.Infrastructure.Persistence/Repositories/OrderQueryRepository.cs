using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using Optivem.Atomiv.Template.Core.Application.Orders.Repositories;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.Repositories
{
    public class OrderQueryRepository : Repository, IOrderQueryRepository
    {
        public OrderQueryRepository(DatabaseContext context) : base(context)
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

            var totalRecords = await Context.Orders.LongCountAsync();

            return new BrowseOrdersQueryResponse
            {
                Records = recordResponses,
                TotalRecords = totalRecords,
            };
        }

        public async Task<ViewOrderQueryResponse> QueryAsync(ViewOrderQuery query)
        {
            var orderId = query.Id;

            var orderRecord = await Context.Orders.AsNoTracking()
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderId);

            if (orderRecord == null)
            {
                return null;
            }

            return GetOrder(orderRecord);
        }

        public async Task<FilterOrdersQueryResponse> QueryAsync(FilterOrdersQuery query)
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .OrderBy(e => e.Id)
                .ToListAsync();

            var resultRecords = orderRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await Context.Orders.LongCountAsync();

            return new FilterOrdersQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
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

        private ViewOrderQueryResponse GetOrder(OrderRecord record)
        {
            var orderItems = record.OrderItems
                .Select(GetFindOrderItemQueryResponse)
                .ToList();

            return new ViewOrderQueryResponse
            {
                Id = record.Id,
                CustomerId = record.CustomerId,
                Status = record.OrderStatusId,
                OrderItems = orderItems,
            };
        }

        private FindOrderItemQueryResponse GetFindOrderItemQueryResponse(OrderItemRecord orderItemRecord)
        {
            return new FindOrderItemQueryResponse
            {
                Id = orderItemRecord.Id,
                ProductId = orderItemRecord.ProductId,
                Quantity = orderItemRecord.Quantity,
                UnitPrice = orderItemRecord.UnitPrice,
                Status = orderItemRecord.StatusId,
            };
        }

    }
}
