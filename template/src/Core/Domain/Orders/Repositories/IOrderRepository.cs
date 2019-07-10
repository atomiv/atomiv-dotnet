using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders.Entities;
using Optivem.Template.Core.Domain.Orders.ValueObjects;

namespace Optivem.Template.Core.Domain.Orders.Repositories
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>, IPageAggregatesRepository<Order, OrderIdentity>
    {
    }
}