using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRepository : Repository<Order, OrderIdentity>, IOrderRepository
    {
        public OrderRepository(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<Order> AddAsync(Order aggregateRoot)
        {
            return HandleAddAggregateRootAsync(aggregateRoot);
        }

        public Task<bool> ExistsAsync(OrderIdentity identity)
        {
            return HandleExistsAggregateRootAsync(identity);
        }

        public Task<Order> FindAsync(OrderIdentity identity)
        {
            return HandleFindAggregateRootAsync(identity);
        }

        public Task<IEnumerable<Order>> ListAsync()
        {
            return HandleListAggregateRootsAsync();
        }

        public Task<PageAggregateRootsResponse<Order>> PageAsync(int page, int size)
        {
            return HandlePageAggregateRootsAsync(page, size);
        }

        public Task RemoveAsync(OrderIdentity identity)
        {
            return HandleRemoveAggregateRootAsync(identity);
        }

        public Task UpdateAsync(Order aggregateRoot)
        {
            return HandleUpdateAggregateRootAsync(aggregateRoot);
        }
    }
}