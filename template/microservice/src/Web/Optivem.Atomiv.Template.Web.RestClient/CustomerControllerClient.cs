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
    public class CustomerControllerClient : ICustomerControllerClient
    {
        private readonly JsonHttpControllerClient _controllerClient;

        public CustomerControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _controllerClient = new JsonHttpControllerClient(httpClient, jsonSerializer, "api/customers");
        }

        #region Commands

        public Task<ObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request, HeaderData header)
        {
            return _controllerClient.PostAsync<CreateCustomerCommand, CreateCustomerCommandResponse>(request);
        }

        public Task<ObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request, HeaderData header)
        {
            var id = request.Id;
            return _controllerClient.DeleteByIdAsync<Guid, DeleteCustomerCommandResponse>(id);
        }

        public Task<ObjectClientResponse<EditCustomerCommandResponse>> EditCustomerAsync(EditCustomerCommand request, HeaderData header)
        {
            return _controllerClient.PutByIdAsync<Guid, EditCustomerCommand, EditCustomerCommandResponse>(request.Id, request);
        }

        #endregion

        #region Queries

        public Task<ObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request, HeaderData header)
        {
            return _controllerClient.GetAsync<BrowseCustomersQuery, BrowseCustomersQueryResponse>(request);
        }

        public Task<ObjectClientResponse<FilterCustomersQueryResponse>> FilterCustomersAsync(FilterCustomersQuery request, HeaderData header)
        {
            return _controllerClient.GetAsync<FilterCustomersQuery, FilterCustomersQueryResponse>("filter", request);
        }

        public Task<ObjectClientResponse<ViewCustomerQueryResponse>> ViewCustomerAsync(ViewCustomerQuery request, HeaderData header)
        {
            var id = request.Id;
            return _controllerClient.GetByIdAsync<Guid, ViewCustomerQueryResponse>(id);
        }

        #endregion
    }
}