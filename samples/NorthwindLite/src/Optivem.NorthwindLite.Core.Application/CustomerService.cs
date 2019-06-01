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
        public CustomerService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<ListCustomersResponse> ListCustomersAsync()
        {
            return ListAsync<ListCustomersRequest, ListCustomersResponse>();
        }

        public Task<FindCustomerResponse> FindCustomerAsync(int id)
        {
            return FindAsync<int, FindCustomerRequest, FindCustomerResponse>(id);
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return CreateAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return UpdateAsync<UpdateCustomerRequest, UpdateCustomerResponse>(request);
        }
    }
}