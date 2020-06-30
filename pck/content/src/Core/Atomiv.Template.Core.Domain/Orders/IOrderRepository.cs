using Atomiv.Core.Domain;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Orders
{
    public interface IOrderRepository : IOrderReadonlyRepository, IRepository
    {
        Task AddAsync(Order order);

        Task<Order> FindAsync(OrderIdentity orderId);

        Task RemoveAsync(OrderIdentity orderId);

        Task UpdateAsync(Order order);
    }
}