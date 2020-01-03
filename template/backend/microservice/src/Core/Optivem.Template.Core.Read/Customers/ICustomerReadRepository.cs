using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Customers
{
    // TODO: VC: Remove dependency on domain for IRepository
    public interface ICustomerReadRepository : IRepository
    {
        Task<ListReadModel<CustomerIdNameReadModel>> ListAsync(string nameSearch, int limit);

        Task<PageReadModel<CustomerHeaderReadModel>> GetPageAsync(PageQuery pageQuery);

        Task<CustomerDetailReadModel> GetDetailAsync(CustomerIdentity customerId);

        Task<long> CountAsync();
    }
}
