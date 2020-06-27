using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.Orders
{
    public class OrderReadonlyRepository : Repository, IOrderReadonlyRepository
    {
        public OrderReadonlyRepository(MongoDbContext context) : base(context)
        {
        }

        public Task<long> CountAsync()
        {
            return Context.Orders
                .CountDocumentsAsync();
        }

        public Task<bool> ExistsAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.TryToObjectId();

            if (orderRecordId == null)
            {
                return Task.FromResult(false);
            }

            return Context.Orders
                .Find(e => e.Id == orderRecordId)
                .AnyAsync();
        }
    }
}
