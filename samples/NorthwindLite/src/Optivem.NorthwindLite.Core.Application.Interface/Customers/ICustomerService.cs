using Optivem.Core.Application;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Core.Application.Customers
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