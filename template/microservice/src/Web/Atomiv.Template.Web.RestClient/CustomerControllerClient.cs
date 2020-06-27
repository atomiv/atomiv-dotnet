using Atomiv.Core.Common.Http;
using Atomiv.Core.Common.Serialization;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Web.RestClient.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Atomiv.Template.Web.RestClient
{
    public class CustomerControllerClient : BaseJsonControllerClient, ICustomerControllerClient
    {
        public CustomerControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
            : base(httpClient, jsonSerializer, "api/customers")
        {

        }

        #region Commands

        public Task<ObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request, HeaderData header)
        {
            return Client.PostAsync<CreateCustomerCommand, CreateCustomerCommandResponse>(request, GetHeaders(header));
        }

        public Task<ObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request, HeaderData header)
        {
            var id = request.Id;
            return Client.DeleteByIdAsync<string, DeleteCustomerCommandResponse>(id, GetHeaders(header));
        }

        public Task<ObjectClientResponse<EditCustomerCommandResponse>> EditCustomerAsync(EditCustomerCommand request, HeaderData header)
        {
            return Client.PutByIdAsync<string, EditCustomerCommand, EditCustomerCommandResponse>(request.Id, request, GetHeaders(header));
        }

        #endregion

        #region Queries

        public Task<ObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request, HeaderData header)
        {
            return Client.GetAsync<BrowseCustomersQuery, BrowseCustomersQueryResponse>(request, GetHeaders(header));
        }

        public Task<ObjectClientResponse<FilterCustomersQueryResponse>> FilterCustomersAsync(FilterCustomersQuery request, HeaderData header)
        {
            return Client.GetAsync<FilterCustomersQuery, FilterCustomersQueryResponse>("filter", request, GetHeaders(header));
        }

        public Task<ObjectClientResponse<ViewCustomerQueryResponse>> ViewCustomerAsync(ViewCustomerQuery request, HeaderData header)
        {
            var id = request.Id;
            return Client.GetByIdAsync<string, ViewCustomerQueryResponse>(id, GetHeaders(header));
        }

        #endregion
    }
}