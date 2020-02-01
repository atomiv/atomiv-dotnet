using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient.Interface
{
    public interface ICustomerControllerClient : IHttpControllerClient
    {
        #region Commands

        Task<IObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request);

        Task<IObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request);

        Task<IObjectClientResponse<EditCustomerCommandResponse>> EditCustomerAsync(EditCustomerCommand request);

        #endregion

        #region Queries

        Task<IObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request);

        Task<IObjectClientResponse<FindCustomerQueryResponse>> FindCustomerAsync(FindCustomerQuery request);

        Task<IObjectClientResponse<ListCustomersQueryResponse>> ListCustomersAsync(ListCustomersQuery request);

        #endregion
    }
}