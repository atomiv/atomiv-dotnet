using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Web.AspNetCore.Rest.Test
{
    public class RestTestServiceClient
    {
        public RestTestServiceClient(RestServiceClient serviceClient)
        {
            Values = new RestControllerClient<int, string>(serviceClient, "api/values");
            Exceptions = new RestControllerClient<int, string>(serviceClient, "api/exceptions");
            Customers = new CustomersControllerClient(serviceClient, "api/customers");
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
