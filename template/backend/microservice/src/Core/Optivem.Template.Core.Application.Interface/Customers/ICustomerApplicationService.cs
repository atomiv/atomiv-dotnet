using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers
{
    public interface ICustomerApplicationService : IApplicationService
    {
        Task<BrowseCustomersResponse> BrowseCustomersAsync(BrowseCustomersRequest request);

        Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

        Task DeleteCustomerAsync(Guid id);

        Task<FindCustomerResponse> FindCustomerAsync(Guid id);

        Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request);

        Task<CustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);
    }
}