using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderReadRepository : Repository, IOrderReadRepository
    {
        public OrderReadRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(OrderIdentity orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FindAsync(OrderIdentity orderId)
        {
            throw new NotImplementedException();
        }

        public Task<PageReadModel<OrderHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            throw new NotImplementedException();
        }

        public Task<ListReadModel<int>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
