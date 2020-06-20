using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Orders
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>, IPageAggregatesRepository<Order, OrderIdentity>
    {
    }
}