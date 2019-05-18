using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.Test.Xunit.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Web.Test.Fixture
{
    // TODO: VC

    public class Client : BaseJsonClient<Startup>
    {
        public Client()
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
    }
}
