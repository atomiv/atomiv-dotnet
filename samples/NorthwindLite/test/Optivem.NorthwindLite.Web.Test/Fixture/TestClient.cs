using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
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
    }
}
