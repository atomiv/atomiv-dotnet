using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerRepository : ICustomerReadRepository
    {
        Task<Customer> AddAsync(Customer customer);

        Task<Customer> UpdateAsync(Customer customer);

        Task RemoveAsync(CustomerIdentity customerId);
    }
}