using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Platform.Test.Infrastructure.Common.RestClient.Default
{
    public class RestControllerClientFixture
    {
        public RestControllerClientFixture()
        {
            var jsonSerializationService = new JsonSerializationService();

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
            };

            TodosClient = new RestControllerClient<int>(httpClient, "todos", jsonSerializationService);
        }

        public IRestControllerClient<int> TodosClient { get; }
    }
}
