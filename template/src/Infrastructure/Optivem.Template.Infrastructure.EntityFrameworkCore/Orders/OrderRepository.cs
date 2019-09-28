using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRepository : CrudRepository<DatabaseContext, Order, OrderIdentity, OrderRecord, int>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context, IMapper mapper) 
            : base(context, mapper, e => e.OrderDetails)
        {
        }

        public IEnumerable<Order> Get(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> PageAsync(int page, int size)
        {
            throw new NotImplementedException();
        }




    }
}
