using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders.Handlers
{
    public class AddOrderHandler : AddAggregateRootHandler<DatabaseContext, Order, OrderIdentity, OrderRecord, int>
    {
        public AddOrderHandler(DatabaseContext context, IAddAggregateRootMapper<Order, OrderRecord> addAggregateRootMapper, IGetAggregateRootMapper<Order, OrderRecord> getAggregateRootMapper) : base(context, addAggregateRootMapper, getAggregateRootMapper)
        {
        }
    }
}