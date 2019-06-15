using Optivem.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>
    {
    }
}