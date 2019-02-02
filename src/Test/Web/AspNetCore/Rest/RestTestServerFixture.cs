using Microsoft.AspNetCore.Hosting;
using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using Optivem.Platform.Test.Web.AspNetCore.Common;
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
            var jsonSerializationService = new JsonSerializationService();
            ValuesControllerClient = new RestControllerClient<int, string>(HttpClient, "api/values", jsonSerializationService);
        }

        public IRestControllerClient<int, string> ValuesControllerClient { get; }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseStartup<Startup>();
        }
    }
}
