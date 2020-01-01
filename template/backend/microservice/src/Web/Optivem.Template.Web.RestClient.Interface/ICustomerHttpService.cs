using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
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