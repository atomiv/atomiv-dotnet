using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization;
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

            TodosClient = new TodosControllerClient(httpClient, jsonSerializationService);
        }

        public TodosControllerClient TodosClient { get; }
    }

    public class TodoDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }

    public class TodosControllerClient : RestControllerClient<int, TodoDto>
    {
        public TodosControllerClient(HttpClient client, ISerializationService jsonSerializationService) 
            : base(client, "todos", jsonSerializationService)
        {
        }
    }
}
