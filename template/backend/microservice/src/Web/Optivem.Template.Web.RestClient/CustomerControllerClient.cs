using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient
{
    public class CustomerControllerClient : ICustomerControllerClient
    {
        private readonly JsonHttpControllerClient _controllerClient;

        public CustomerControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _controllerClient = new JsonHttpControllerClient(httpClient, jsonSerializer, "api/customers");
        }

        public Task<IObjectClientResponse<BrowseCustomersQueryResponse>> BrowseCustomersAsync(BrowseCustomersQuery request)
        {
            return _controllerClient.GetAsync<BrowseCustomersQuery, BrowseCustomersQueryResponse>(request);
        }

        public Task<IObjectClientResponse<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request)
        {
            return _controllerClient.PostAsync<CreateCustomerCommand, CreateCustomerCommandResponse>(request);
        }

        public Task<IObjectClientResponse<DeleteCustomerCommandResponse>> DeleteCustomerAsync(DeleteCustomerCommand request)
        {
            var id = request.Id;
            return _controllerClient.DeleteByIdAsync<Guid, DeleteCustomerCommandResponse>(id);
        }

        public Task<IObjectClientResponse<FindCustomerQueryResponse>> FindCustomerAsync(FindCustomerQuery request)
        {
            var id = request.Id;
            return _controllerClient.GetByIdAsync<Guid, FindCustomerQueryResponse>(id);
        }

        public Task<IObjectClientResponse<ListCustomersQueryResponse>> ListCustomersAsync(ListCustomersQuery request)
        {
            return _controllerClient.GetAsync<ListCustomersQuery, ListCustomersQueryResponse>("list", request);
        }

        public Task<IObjectClientResponse<UpdateCustomerCommandResponse>> UpdateCustomerAsync(UpdateCustomerCommand request)
        {
            return _controllerClient.PutByIdAsync<Guid, UpdateCustomerCommand, UpdateCustomerCommandResponse>(request.Id, request);
        }
    }
}