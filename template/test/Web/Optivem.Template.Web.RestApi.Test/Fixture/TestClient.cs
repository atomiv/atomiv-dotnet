using Optivem.Core.Common.Http;
using Optivem.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Interface.Customers.Requests;
using Optivem.Template.Core.Application.Interface.Customers.Responses;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Test.AspNetCore.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Optivem.Template.Web.Test.Fixture
{
    // TODO: VC

    public class TestClient : BaseTestClient<Startup, DatabaseContext>
    {
        public TestClient()
            : base(Startup.DatabaseConnectionKey, e => new DatabaseContext(e))
        {
            Customers = new CustomersControllerClient(Client.ControllerClientFactory);
        }

        public CustomersControllerClient Customers { get; }
    }

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