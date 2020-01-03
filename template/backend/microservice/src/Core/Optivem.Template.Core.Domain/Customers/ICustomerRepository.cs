using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerRepository : IRepository
    {
        Task AddAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task RemoveAsync(CustomerIdentity customerId);
        Task<Customer> FindAsync(CustomerIdentity customerId);
    }
}