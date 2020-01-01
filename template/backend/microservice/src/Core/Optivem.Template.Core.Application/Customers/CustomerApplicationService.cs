using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
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
            return HandleAsync(request);
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return HandleAsync(request);
        }

        public Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            return HandleAsync(request);
        }

        public Task<FindCustomerResponse> FindCustomerAsync(FindCustomerRequest request)
        {
            return HandleAsync(request);
        }

        public Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request)
        {
            return HandleAsync(request);
        }

        public Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return HandleAsync(request);
        }
    }
}