using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface ICustomerHttpService : IHttpService
    {
        Task<IObjectClientResponse<BrowseCustomersResponse>> BrowseCustomersAsync(BrowseCustomersRequest request);

        Task<IObjectClientResponse<CustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request);

        Task<IObjectClientResponse<VoidResponse>> DeleteCustomerAsync(DeleteCustomerRequest request);

        Task<IObjectClientResponse<FindCustomerResponse>> FindCustomerAsync(FindCustomerRequest request);

        Task<IObjectClientResponse<ListCustomersResponse>> ListCustomersAsync(ListCustomersRequest request);

        Task<IObjectClientResponse<CustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request);
    }
}