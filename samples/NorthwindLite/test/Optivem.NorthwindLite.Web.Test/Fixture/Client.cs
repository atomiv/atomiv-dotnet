using Optivem.Test.Xunit.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Web.Test.Fixture
{
    // TODO: VC

    public class Client : BaseClient<Startup>
    {
        public Client()
        {
            // Customers = new CustomersControllerClient(RestServiceClient, "api/customers");
        }

        // public CustomersControllerClient Customers { get; }
    }

    /*
    public class CustomersControllerClient
        : RestControllerClient<int, CustomerGetCollectionResponse,
            CustomerGetResponse,
            CustomerPostRequest, CustomerPostResponse,
            CustomerPutRequest, CustomerPutResponse>
    {
        public CustomersControllerClient(RestServiceClient serviceClient, string controllerPath)
            : base(serviceClient, controllerPath)
        {
        }
    }
    */
}
