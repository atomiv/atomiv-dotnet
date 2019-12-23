using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers
{
    public class CustomerApplicationService : ApplicationService, ICustomerApplicationService
    {
        public CustomerApplicationService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<BrowseCustomersResponse> BrowseCustomersAsync(BrowseCustomersRequest request)
        {
            return HandleAsync<BrowseCustomersRequest, BrowseCustomersResponse>(request);
        }

        public Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return HandleAsync<CreateCustomerRequest, CustomerResponse>(request);
        }

        public Task DeleteCustomerAsync(Guid id)
        {
            var request = new DeleteCustomerRequest
            {
                Id = id,
            };

            return HandleAsync<DeleteCustomerRequest, VoidResponse>(request);
        }

        public Task<FindCustomerResponse> FindCustomerAsync(Guid id)
        {
            var request = new FindCustomerRequest
            {
                Id = id,
            };

            return HandleAsync<FindCustomerRequest, FindCustomerResponse>(request);
        }

        public Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request)
        {
            return HandleAsync<ListCustomersRequest, ListCustomersResponse>(request);
        }

        public Task<CustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return HandleAsync<UpdateCustomerRequest, CustomerResponse>(request);
        }
    }
}