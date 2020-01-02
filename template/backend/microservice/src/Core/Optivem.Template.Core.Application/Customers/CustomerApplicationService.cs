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

        public Task<BrowseCustomersQueryResponse> BrowseCustomersAsync(BrowseCustomersQuery request)
        {
            return HandleAsync(request);
        }

        public Task<CreateCustomerCommandResponse> CreateCustomerAsync(CreateCustomerCommand request)
        {
            return HandleAsync(request);
        }

        public Task<DeleteCustomerCommandResponse> DeleteCustomerAsync(DeleteCustomerCommand request)
        {
            return HandleAsync(request);
        }

        public Task<FindCustomerQueryResponse> FindCustomerAsync(FindCustomerQuery request)
        {
            return HandleAsync(request);
        }

        public Task<ListCustomersQueryResponse> ListCustomersAsync(ListCustomersQuery request)
        {
            return HandleAsync(request);
        }

        public Task<UpdateCustomerCommandResponse> UpdateCustomerAsync(UpdateCustomerCommand request)
        {
            return HandleAsync(request);
        }
    }
}