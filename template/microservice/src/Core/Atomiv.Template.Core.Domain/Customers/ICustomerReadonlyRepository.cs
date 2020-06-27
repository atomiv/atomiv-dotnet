using Atomiv.Core.Domain;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Customers
{
    public interface ICustomerReadonlyRepository : IRepository
    {
        Task<bool> ExistsAsync(CustomerIdentity customerId);

        Task<long> CountAsync();
    }
}
