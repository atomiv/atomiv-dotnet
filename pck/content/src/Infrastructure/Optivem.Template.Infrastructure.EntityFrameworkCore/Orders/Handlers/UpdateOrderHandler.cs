using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders.Handlers
{
    public class UpdateOrderHandler : UpdateAggregateRootHandler<DatabaseContext, Order, OrderIdentity, OrderRecord, int>
    {
        public UpdateOrderHandler(DatabaseContext context, IUpdateAggregateRootMapper<Order, OrderRecord> updateAggregateRootMapper, IGetAggregateRootMapper<Order, OrderRecord> getAggregateRootMapper) 
            : base(context, updateAggregateRootMapper, getAggregateRootMapper)
        {
        }
    }
}