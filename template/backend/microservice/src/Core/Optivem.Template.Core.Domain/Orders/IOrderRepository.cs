using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderRepository : IRepository
    {
        void Add(Order order);

        Task UpdateAsync(Order order);

        void Remove(OrderIdentity orderId);

        Task<Order> FindAsync(OrderIdentity orderId);
    }
}