using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.All;
using Optivem.Framework.Test.Web.AspNetCore.Rest.Fake;
using Optivem.Framework.Test.Xunit.Web.AspNetCore;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Models;

namespace Optivem.Framework.Web.AspNetCore.Rest.Test
{
    // TODO: VC: Consider moving into Fixtures folder

    public class RestTestServerFixture : TestServerFixture
    {
        public RestTestServerFixture() 
            : base(CreateWebHostBuilder())
        {
            var serializationService = new SerializationService();

            // TODO: VC: Consider factory for controllers, taking params client & serialization service

            ValuesControllerClient = new RestControllerClient<int, string>(HttpClient, "api/values", serializationService);
            ExceptionsControllerClient = new RestControllerClient<int, string>(HttpClient, "api/exceptions", serializationService);
            CustomersControllerClient = new CustomersControllerClient(HttpClient, serializationService);
        }

        public IRestControllerClient<int, string> ValuesControllerClient { get; }

        public IRestControllerClient<int, string> ExceptionsControllerClient { get; }

        public CustomersControllerClient CustomersControllerClient { get; }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseStartup<Startup>();
        }
    }

    public class CustomersControllerClient
        : RestControllerClient<int, CustomerGetCollectionResponse,
            CustomerGetResponse,
            CustomerPostRequest, CustomerPostResponse,
            CustomerPutRequest, CustomerPutResponse>
    {
        public CustomersControllerClient(HttpClient client, ISerializationService serializationService) 
            : base(client, "api/customers", serializationService)
        {
        }
    }

}
