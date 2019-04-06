using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Default;
using Optivem.Platform.Test.Wed.AspNetCore.Rest.Fake;
using Optivem.Platform.Test.Xunit.Web.AspNetCore;
using Optivem.Platform.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using Optivem.Platform.Web.AspNetCore.Rest.Fake.Models;

namespace Optivem.Platform.Web.AspNetCore.Rest.Test
{
    public class RestTestServerFixture : TestServerFixture
    {
        public RestTestServerFixture() 
            : base(CreateWebHostBuilder())
        {
            var serializationService = new SerializationService();

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
