using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.Framework.Test.Web.AspNetCore.Rest.Fake;
using Optivem.Test.Xunit.AspNetCore;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Models;

namespace Optivem.Web.AspNetCore.Test
{
    // TODO: VC: Consider moving into Fixtures folder

    public class Client : BaseClient<Startup>
    {
        public Client()
        {
            Values = new RestControllerClient<int, string>(RestServiceClient, "api/values");
            Exceptions = new RestControllerClient<int, string>(RestServiceClient, "api/exceptions");
            Customers = new CustomersControllerClient(RestServiceClient, "api/customers");
        }

        public IRestControllerClient<int, string> Values { get; }

        public IRestControllerClient<int, string> Exceptions { get; }

        public CustomersControllerClient Customers { get; }
    }

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



}
