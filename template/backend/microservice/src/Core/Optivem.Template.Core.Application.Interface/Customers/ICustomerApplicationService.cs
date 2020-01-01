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

        Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

        Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request);

        Task<FindCustomerResponse> FindCustomerAsync(FindCustomerRequest request);

        Task<ListCustomersResponse> ListCustomersAsync(ListCustomersRequest request);

        Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);
    }
}