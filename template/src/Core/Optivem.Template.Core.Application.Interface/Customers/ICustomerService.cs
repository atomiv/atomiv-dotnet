using Optivem.Core.Application;
using Optivem.Template.Core.Application.Interface.Customers.Requests;
using Optivem.Template.Core.Application.Interface.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Interface.Customers
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