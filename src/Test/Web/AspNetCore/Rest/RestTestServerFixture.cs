using Microsoft.AspNetCore.Hosting;
using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using Optivem.Platform.Infrastructure.Common.Serialization.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using Optivem.Platform.Test.Web.AspNetCore.Common;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;
using Optivem.Platform.Test.Wed.AspNetCore.Rest.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest
{
    public class RestTestServerFixture : TestServerFixture
    {
        public RestTestServerFixture() 
            : base(CreateWebHostBuilder())
        {
            var serializationService = new SerializationService();

            ValuesControllerClient = new RestControllerClient<int, string>(HttpClient, "api/values", serializationService);
            CustomersControllerClient = new RestControllerClient<int, CustomerDto>(HttpClient, "api/customers", serializationService);
        }

        public IRestControllerClient<int, string> ValuesControllerClient { get; }

        public IRestControllerClient<int, CustomerDto> CustomersControllerClient { get; }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseStartup<Startup>();
        }
    }
}
