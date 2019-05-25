using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Infrastructure.Persistence;
using Optivem.Test.AspNetCore.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Web.Test.Fixture
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
    }
}