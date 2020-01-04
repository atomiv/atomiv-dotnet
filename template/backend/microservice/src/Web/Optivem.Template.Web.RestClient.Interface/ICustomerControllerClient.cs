using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface ICustomerControllerClient : IHttpControllerClient
    {
        Task<IObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request);

        Task<IObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request);

        Task<IObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request);

        Task<IObjectClientResponse<FindCustomerQueryResponse>> FindCustomerAsync(FindCustomerQuery request);

        Task<IObjectClientResponse<ListCustomersQueryResponse>> ListCustomersAsync(ListCustomersQuery request);

        Task<IObjectClientResponse<UpdateCustomerCommandResponse>> UpdateCustomerAsync(UpdateCustomerCommand request);
    }
}