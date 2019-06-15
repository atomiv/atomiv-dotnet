using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Orders
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>
    {
    }
}