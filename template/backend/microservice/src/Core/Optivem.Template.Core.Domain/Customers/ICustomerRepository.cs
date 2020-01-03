using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerRepository : ICustomerReadRepository
    {
        Task AddAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task RemoveAsync(CustomerIdentity customerId);
    }
}