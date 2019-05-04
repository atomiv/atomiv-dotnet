using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.All;
using System;
using System.Net.Http;

namespace Optivem.Framework.Infrastructure.Common.RestClient.Default.Test
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
