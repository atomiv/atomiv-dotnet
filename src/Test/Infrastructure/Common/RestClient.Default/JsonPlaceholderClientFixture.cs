using Optivem.Platform.Core.Common.Serialization;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Platform.Test.Infrastructure.Common.RestClient.Default
{
    public class JsonPlaceholderClientFixture
    {
        public JsonPlaceholderClientFixture()
        {
            var serializationService = new SerializationService();

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
            };

            JsonPlaceholderClient = new JsonPlaceholderClient(httpClient, serializationService);
        }

        public JsonPlaceholderClient JsonPlaceholderClient { get; }
    }

    public class JsonPlaceholderClient
    {
        public JsonPlaceholderClient(HttpClient client, ISerializationService serializationService)
        {
            Posts = new PostsControllerClient(client, serializationService);
            Todos = new TodosControllerClient(client, serializationService);
        }

        public PostsControllerClient Posts { get; }

        public TodosControllerClient Todos { get; }

    }

    public class PostsControllerClient : RestControllerClient<int, Post>
    {
        public PostsControllerClient(HttpClient client, ISerializationService serializationService)
            : base(client, "posts", serializationService)
        {
        }
    }

    public class TodosControllerClient : RestControllerClient<int, TodoDto>
    {
        public TodosControllerClient(HttpClient client, ISerializationService serializationService)
            : base(client, "todos", serializationService)
        {
        }
    }

    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }

    public class TodoDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
