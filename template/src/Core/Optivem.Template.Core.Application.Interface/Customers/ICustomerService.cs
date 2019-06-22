using Optivem.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers
{
    public interface ICustomerService : IApplicationService
    {
        Task<ListCustomersResponse> ListCustomersAsync();

        Task<FindCustomerResponse> FindCustomerAsync(int id);

        Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

        Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);

        Task DeleteCustomerAsync(int id);
    }
}