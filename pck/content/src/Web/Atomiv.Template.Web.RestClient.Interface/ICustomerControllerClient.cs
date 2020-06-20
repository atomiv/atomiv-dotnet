using Atomiv.Core.Common.Http;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Queries.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Web.RestClient.Interface
{
    public interface ICustomerControllerClient : IHttpControllerClient
    {
        #region Commands

        Task<ObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request, HeaderData header);

        Task<ObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request, HeaderData header);

        Task<ObjectClientResponse<EditCustomerCommandResponse>> EditCustomerAsync(EditCustomerCommand request, HeaderData header);

        #endregion

        #region Queries

        Task<ObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request, HeaderData header);

        Task<ObjectClientResponse<FilterCustomersQueryResponse>> FilterCustomersAsync(FilterCustomersQuery request, HeaderData header);

        Task<ObjectClientResponse<ViewCustomerQueryResponse>> ViewCustomerAsync(ViewCustomerQuery request, HeaderData header);

        #endregion
    }
}