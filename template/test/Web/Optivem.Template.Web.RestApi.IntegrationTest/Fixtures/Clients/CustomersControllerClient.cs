using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.IntegrationTest.Fixtures.Clients
{
    public class CustomersControllerClient : BaseControllerClient
    {
        public CustomersControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/customers")
        {
        }

        public Task<IObjectClientResponse<ListCustomersResponse>> ListCustomersAsync()
        {
            return Client.GetAsync<ListCustomersResponse>();
        }

        public Task<IObjectClientResponse<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return Client.PostAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<IObjectClientResponse<FindCustomerResponse>> FindCustomerAsync(int id)
        {
            return Client.GetByIdAsync<int, FindCustomerResponse>(id);
        }

        public Task<IObjectClientResponse<UpdateCustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return Client.PutByIdAsync<int, UpdateCustomerRequest, UpdateCustomerResponse>(request.Id, request);
        }

        public Task<IClientResponse> DeleteCustomerAsync(int id)
        {
            return Client.DeleteByIdAsync(id);
        }
    }
}
