using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerReadRepository : IRepository
    {
        Task<Customer> FindAsync(CustomerIdentity customerId);

        Task<bool> ExistsAsync(CustomerIdentity customerId);

        Task<ListReadModel<CustomerIdNameReadModel>> ListAsync(string nameSearch, int limit);

        Task<PageReadModel<CustomerHeaderReadModel>> GetPageAsync(PageQuery pageQuery);

        Task<CustomerDetailReadModel> GetDetailAsync(CustomerIdentity customerId);

        Task<long> CountAsync();
    }
}
