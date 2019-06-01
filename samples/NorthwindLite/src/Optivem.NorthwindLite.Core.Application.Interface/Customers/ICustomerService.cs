using Optivem.Core.Application;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Core.Application.Interface.Services
{
    public interface ICustomerService : IService
    {
        Task<ListCustomersResponse> ListCustomersAsync();

        Task<FindCustomerResponse> FindCustomerAsync(int id);

        Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

        Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);
    }
}