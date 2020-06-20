using Atomiv.Core.Common.Http;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Generator.Web.RestClient.Interface
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
