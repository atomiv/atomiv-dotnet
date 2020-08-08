using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDB.Orders
{
    public class OrderReadonlyRepository : Repository, IOrderReadonlyRepository
    {
        public OrderReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<long> CountAsync()
        {
            return Context.Orders
                .CountDocumentsAsync();
        }

        public Task<bool> ExistsAsync(OrderIdentity orderId)
        {
            return Context.Orders
                .Find(e => e.Id == orderId)
                .AnyAsync();
        }
    }
}
