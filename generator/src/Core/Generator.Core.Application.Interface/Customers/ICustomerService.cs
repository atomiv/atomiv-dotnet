using Atomiv.Core.Application;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Generator.Core.Application.Customers
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