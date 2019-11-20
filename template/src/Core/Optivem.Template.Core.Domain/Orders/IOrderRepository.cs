using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderRepository : IOrderReadRepository
    {
        Task<Order> AddAsync(Order order);

        Task<Order> UpdateAsync(Order order);

        Task RemoveAsync(OrderIdentity orderId);
    }
}