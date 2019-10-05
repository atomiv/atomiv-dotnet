using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderRepository : IRepository<Order, OrderIdentity>,
        IFindAggregateRootRepository<Order, OrderIdentity>,
        IExistsAggregateRootRepository<Order, OrderIdentity>,
        IAddAggregateRootRepository<Order, OrderIdentity>,
        IUpdateAggregateRootRepository<Order, OrderIdentity>,
        IRemoveAggregateRootRepository<Order, OrderIdentity>,
        IPageAggregateRootsRepository<Order, OrderIdentity>,
        IListAggregateRootsRepository<Order, OrderIdentity>
    {
    }
}