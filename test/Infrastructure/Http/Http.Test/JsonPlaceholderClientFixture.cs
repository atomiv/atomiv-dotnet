using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Test.Xunit;
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

            var serviceClient = new RestServiceClient(serializationService, httpClient);

            JsonPlaceholderClient = new JsonPlaceholderClient(serviceClient);
        }

        public JsonPlaceholderClient JsonPlaceholderClient { get; }
    }

    public class JsonPlaceholderClient
    {
        public JsonPlaceholderClient(RestServiceClient serviceClient)
        {
            Posts = new PostsControllerClient(serviceClient);
            Todos = new TodosControllerClient(serviceClient);
        }

        public PostsControllerClient Posts { get; }

        public TodosControllerClient Todos { get; }

    }

    public class PostsControllerClient : RestControllerClient<int, Post>
    {
        public PostsControllerClient(RestServiceClient serviceClient)
            : base(serviceClient, "posts")
        {
        }
    }

    public class TodosControllerClient : RestControllerClient<int, TodoDto>
    {
        public TodosControllerClient(RestServiceClient serviceClient)
            : base(serviceClient, "todos")
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
