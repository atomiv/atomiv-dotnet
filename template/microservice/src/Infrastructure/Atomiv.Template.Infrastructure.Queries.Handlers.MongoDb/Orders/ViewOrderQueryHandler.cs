using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Orders
{
    public class ViewOrderQueryHandler : QueryHandler<ViewOrderQuery, ViewOrderQueryResponse>
    {
        public ViewOrderQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override async Task<ViewOrderQueryResponse> HandleAsync(ViewOrderQuery request)
        {
            var orderRecordId = request.Id.TryToObjectId();

            if (orderRecordId == null)
            {
                throw new ExistenceException();
            }

            var orderRecord = await Context.Orders
                .Find(e => e.Id == orderRecordId)
                .FirstOrDefaultAsync();

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
                Id = record.Id.ToString(),
                CustomerId = record.CustomerId.ToString(),
                Status = record.OrderStatusId,
                OrderItems = orderItems,
            };
        }

        private FindOrderItemQueryResponse GetResponse(OrderItemRecord orderItemRecord)
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
