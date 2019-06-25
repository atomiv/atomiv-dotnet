using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Services;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<BrowseCustomersResponse> BrowseCustomersAsync(BrowseCustomersRequest request)
        {
            return HandleAsync<BrowseCustomersRequest, BrowseCustomersResponse>(request);
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return HandleAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            return HandleAsync<DeleteCustomerRequest, DeleteCustomerResponse>(request);
        }

        public Task<FindCustomerResponse> FindCustomerAsync(FindCustomerRequest request)
        {
            return HandleAsync<FindCustomerRequest, FindCustomerResponse>(request);
        }

        public Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request)
        {
            return HandleAsync<ListCustomersRequest, ListCustomersResponse>(request);
        }

        public Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return HandleAsync<UpdateCustomerRequest, UpdateCustomerResponse>(request);
        }

    }
}