using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Orders
{
    public interface IOrderReadRepository : IRepository
    {
        Task<Order> FindAsync(OrderIdentity orderId);

        Task<bool> ExistsAsync(OrderIdentity orderId);

        Task<ListReadModel<OrderIdNameReadModel>> ListAsync();

        Task<PageReadModel<OrderHeaderReadModel>> GetPageAsync(PageQuery pageQuery);

        Task<long> CountAsync();
    }
}
