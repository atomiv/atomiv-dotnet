using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Domain.Orders.Entities;
using Optivem.Generator.Core.Domain.Orders.ValueObjects;

namespace Optivem.Generator.Core.Domain.Orders.Repositories
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>, IPageAggregatesRepository<Order, OrderIdentity>
    {
    }
}