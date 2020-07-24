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
            var orderRecordId = request.Id.TryToGuid();

            if(orderRecordId == null)
            {
                throw new ExistenceException();
            }

            var orderRecord = await Context.Orders.AsNoTracking()
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            if (orderRecord == null)
            {
                throw new ExistenceException();
            }

            return GetResponse(orderRecord);
        }

        private ViewOrderQueryResponse GetResponse(OrderRecord record)
        {
            var orderItems = record.OrderItems
                .Select(GetResponse)
                .ToList();

            return new ViewOrderQueryResponse
            {
                Id = record.Id,
                CustomerId = record.CustomerId,
                Status = record.OrderStatusId,
                OrderItems = orderItems,
            };
        }

        private FindOrderItemQueryResponse GetResponse(OrderItemRecord orderItemRecord)
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