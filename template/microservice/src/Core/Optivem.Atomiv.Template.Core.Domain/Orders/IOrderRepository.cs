using Optivem.Atomiv.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Domain.Orders
{
    public interface IOrderRepository : IRepository
    {
        Task AddAsync(Order order);

        Task<Order> FindAsync(OrderIdentity orderId);

        Task RemoveAsync(OrderIdentity orderId);

        Task UpdateAsync(Order order);
    }
}