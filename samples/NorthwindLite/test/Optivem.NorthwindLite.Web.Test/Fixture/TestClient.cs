using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Infrastructure.Persistence;
using Optivem.Test.Xunit.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Web.Test.Fixture
{
    // TODO: VC

    public class TestClient : BaseTestJsonClient<Startup>
    {
        public TestClient()
        {
            Customers = new CustomersControllerClient(ControllerClientFactory);
        }

        public CustomersControllerClient Customers { get; }

        protected override void Setup(IConfigurationRoot configuration)
        {
            // TODO: VC: Refactor with startup
            var connection = configuration.GetConnectionString(Startup.DatabaseContextConnectionStringKey);

            var builder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connection);

            using (var context = new DatabaseContext(builder.Options))
            {
                context.Database.EnsureCreated();
            }
        }
    }

    public class CustomersControllerClient : BaseControllerClient
    {
        public CustomersControllerClient(IControllerClientFactory clientFactory) 
            : base(clientFactory, "api/customers")
        {
        }

        public Task<ListCustomersResponse> ListCustomersAsync()
        {
            return Client.GetAsync<ListCustomersResponse>();
        }

        public Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return Client.PostAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<FindCustomerResponse> FindCustomerAsync(int id)
        {
            return Client.GetByIdAsync<int, FindCustomerResponse>(id);
        }
    }
}
