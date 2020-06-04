using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Domain.Orders;
using Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Domain.Repositories.Orders
{
    public class OrderReadonlyRepository : Repository, IOrderReadonlyRepository
    {
        public OrderReadonlyRepository(DatabaseContext context) : base(context)
        {
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
    }
}
