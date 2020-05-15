using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Queries.Handlers.Orders
{
    public class BrowseOrdersQueryHandler : QueryHandler<BrowseOrdersQuery, BrowseOrdersQueryResponse>
    {
        public BrowseOrdersQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<BrowseOrdersQueryResponse> HandleAsync(BrowseOrdersQuery request)
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .GetPage(request.Page, request.Size)
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
    }
}