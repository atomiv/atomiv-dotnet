using Optivem.Core.Application;
using Optivem.Core.Application.Services;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.BrowseAll;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Application.Interface.Services;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Core.Application
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IUseCaseMediator mediator) : base(mediator)
        {
        }

        public Task<ListCustomersResponse> ListCustomersAsync()
        {
            var request = new ListCustomersRequest();
            return Mediator.HandleAsync<ListCustomersRequest, ListCustomersResponse>(request);
        }

        public Task<FindCustomerResponse> FindCustomerAsync(int id)
        {
            // TODO: VC: Move to base class

            var request = new FindCustomerRequest
            {
                Id = id,
            };

            return Mediator.HandleAsync<FindCustomerRequest, FindCustomerResponse>(request);
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return Mediator.HandleAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }
    }
}