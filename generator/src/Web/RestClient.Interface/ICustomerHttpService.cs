using Optivem.Framework.Core.Common.Http;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.Generator.Web.RestClient.Interface
{
    public interface ICustomerHttpService : IHttpService
    {
        Task<IObjectClientResponse<BrowseCustomersResponse>> BrowseCustomersAsync(BrowseCustomersRequest request);

        Task<IObjectClientResponse<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request);

        Task<IObjectClientResponse<DeleteCustomerResponse>> DeleteCustomerAsync(DeleteCustomerRequest request);

        Task<IObjectClientResponse<FindCustomerResponse>> FindCustomerAsync(FindCustomerRequest request);

        Task<IObjectClientResponse<ListCustomersResponse>> ListCustomersAsync(ListCustomersRequest request);

        Task<IObjectClientResponse<UpdateCustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request);
    }
}
