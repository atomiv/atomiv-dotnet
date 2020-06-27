using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using Atomiv.Template.Infrastructure.Domain.Persistence;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Orders
{
    public class ViewOrderQueryHandler : QueryHandler<ViewOrderQuery, ViewOrderQueryResponse>
    {
        public ViewOrderQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<ViewOrderQueryResponse> HandleAsync(ViewOrderQuery request)
        {
            var orderRecordId = request.Id.ToGuid();

            var orderRecord = await Context.Orders.AsNoTracking()
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            if (orderRecord == null)
            {
                throw new ExistenceException();
            }

            return GetOrder(orderRecord);
        }

        private ViewOrderQueryResponse GetOrder(OrderRecord record)
        {
            var orderItems = record.OrderItems
                .Select(GetFindOrderItemQueryResponse)
                .ToList();

            return new ViewOrderQueryResponse
            {
                Id = record.Id.ToString(),
                CustomerId = record.CustomerId.ToString(),
                Status = record.OrderStatusId,
                OrderItems = orderItems,
            };
        }

        private FindOrderItemQueryResponse GetFindOrderItemQueryResponse(OrderItemRecord orderItemRecord)
        {
            return new FindOrderItemQueryResponse
            {
                Id = orderItemRecord.Id.ToString(),
                ProductId = orderItemRecord.ProductId.ToString(),
                Quantity = orderItemRecord.Quantity,
                UnitPrice = orderItemRecord.UnitPrice,
                Status = orderItemRecord.StatusId,
            };
        }
    }
}