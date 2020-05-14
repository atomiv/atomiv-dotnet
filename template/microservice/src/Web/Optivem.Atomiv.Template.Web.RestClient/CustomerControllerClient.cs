using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using Optivem.Atomiv.Template.Web.RestClient.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient
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
            return Client.PostAsync<CreateCustomerCommand, CreateCustomerCommandResponse>(request);
        }

        public Task<ObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request, HeaderData header)
        {
            var id = request.Id;
            return Client.DeleteByIdAsync<Guid, DeleteCustomerCommandResponse>(id);
        }

        public Task<ObjectClientResponse<EditCustomerCommandResponse>> EditCustomerAsync(EditCustomerCommand request, HeaderData header)
        {
            return Client.PutByIdAsync<Guid, EditCustomerCommand, EditCustomerCommandResponse>(request.Id, request);
        }

        #endregion

        #region Queries

        public Task<ObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request, HeaderData header)
        {
            return Client.GetAsync<BrowseCustomersQuery, BrowseCustomersQueryResponse>(request);
        }

        public Task<ObjectClientResponse<FilterCustomersQueryResponse>> FilterCustomersAsync(FilterCustomersQuery request, HeaderData header)
        {
            return Client.GetAsync<FilterCustomersQuery, FilterCustomersQueryResponse>("filter", request);
        }

        public Task<ObjectClientResponse<ViewCustomerQueryResponse>> ViewCustomerAsync(ViewCustomerQuery request, HeaderData header)
        {
            var id = request.Id;
            return Client.GetByIdAsync<Guid, ViewCustomerQueryResponse>(id);
        }

        #endregion
    }
}