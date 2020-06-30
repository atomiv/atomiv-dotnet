using Atomiv.Core.Domain;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Orders
{
    public interface IOrderReadonlyRepository : IRepository
    {
        Task<bool> ExistsAsync(OrderIdentity orderId);

        Task<long> CountAsync();
    }
}
