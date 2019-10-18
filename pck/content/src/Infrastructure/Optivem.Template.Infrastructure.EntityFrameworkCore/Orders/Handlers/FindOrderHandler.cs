using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders.Handlers
{
    public class FindOrderHandler : FindAggregateRootHandler<DatabaseContext, Order, OrderIdentity, OrderRecord, int>
    {
        public FindOrderHandler(DatabaseContext context, IGetAggregateRootMapper<Order, OrderRecord> aggregateRootFactory) : base(context, aggregateRootFactory)
        {
        }
    }
}