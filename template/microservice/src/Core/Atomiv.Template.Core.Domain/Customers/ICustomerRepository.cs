using Atomiv.Core.Domain;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Customers
{
    public interface ICustomerRepository : IRepository
    {
        Task AddAsync(Customer customer);

        Task<Customer> FindAsync(CustomerIdentity customerId);

        Task RemoveAsync(CustomerIdentity customerId);

        Task UpdateAsync(Customer customer);
    }
}