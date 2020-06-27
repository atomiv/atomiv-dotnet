using Microsoft.EntityFrameworkCore;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Orders
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
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Orders.LongCountAsync();

            return new BrowseOrdersQueryResponse
            {
                Records = recordResponses,
                TotalRecords = totalRecords,
            };
        }

        private BrowseOrdersRecordQueryResponse GetResponse(OrderRecord record)
        {
            var totalPrice = record.OrderItems.Sum(e => e.UnitPrice * e.Quantity);

            return new BrowseOrdersRecordQueryResponse
            {
                Id = record.Id.ToString(),
                CustomerId = record.CustomerId.ToString(),
                OrderDate = record.OrderDate,
                OrderStatus = record.OrderStatusId,
                TotalPrice = totalPrice,
            };
        }
    }
}