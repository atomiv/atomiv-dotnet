using Optivem.Framework.Core.Application;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.Generator.Core.Application.Customers
{
    public interface ICustomerService : IApplicationService
    {
        Task<BrowseCustomersResponse> BrowseCustomersAsync(BrowseCustomersRequest request);

        Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

        Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request);

        Task<FindCustomerResponse> FindCustomerAsync(FindCustomerRequest request);

        Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request);

        Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);
    }
}