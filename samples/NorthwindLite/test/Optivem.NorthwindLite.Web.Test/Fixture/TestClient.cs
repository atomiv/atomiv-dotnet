using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Persistence.EntityFrameworkCore;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Infrastructure.Persistence;
using Optivem.Test.Xunit.AspNetCore.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Web.Test.Fixture
{
    // TODO: VC

    public class TestClient : BaseTestClient<Startup, DatabaseContext>
    {
        public TestClient()
        {
            Customers = new CustomersControllerClient(ControllerClientFactory);
        }

        public CustomersControllerClient Customers { get; }

        protected override DatabaseContext CreateContext(DbContextOptions<DatabaseContext> options)
        {
            return new DatabaseContext(options);
        }
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