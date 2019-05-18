using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;
using Optivem.Test.Xunit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Common.RestClient.Default.Test
{
    public class JsonPlaceholderClientFixture
    {
        public JsonPlaceholderClientFixture()
        {
            var serializationService = new JsonSerializationService();

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
            };

            var client = new Client(httpClient);

            var controllerClientFactory = new JsonControllerClientFactory(client, serializationService);

            JsonPlaceholderClient = new JsonPlaceholderClient(controllerClientFactory);
        }

        public JsonPlaceholderClient JsonPlaceholderClient { get; }
    }

    public class JsonPlaceholderClient
    {
        public JsonPlaceholderClient(IControllerClientFactory controllerClientFactory)
        {
            Posts = new PostsControllerClient(controllerClientFactory);
            Todos = new TodosControllerClient(controllerClientFactory);
        }

        public PostsControllerClient Posts { get; }

        public TodosControllerClient Todos { get; }

    }



    public class PostsControllerClient : BaseControllerClient
    {
        // TODO: VC: Where to set the base: "/posts"

        public PostsControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "posts")
        {
        }

        public Task<PostDto> GetAsync(int id)
        {
            return Client.GetByIdAsync<int, PostDto>(id);
        }

        public Task<List<PostDto>> GetAsync()
        {
            return Client.GetAsync<List<PostDto>>();
        }

        public Task<PostDto> CreateAsync(PostDto post)
        {
            return Client.PostAsync<PostDto, PostDto>(post);
        }

        public Task<PostDto> PutAsync(int id, PostDto post)
        {
            return Client.PutByIdAsync<int, PostDto, PostDto>(id, post);
        }

        public Task DeleteAsync(int id)
        {
            return Client.DeleteByIdAsync(id);
        }

        public Task<List<PostDto>> GetByUserIdAsync(int userId)
        {
            // TODO: VC: Consider dto for filtering..
            return Client.GetAsync<List<PostDto>>($"?userId={userId}");
        }

        public Task<List<CommentDto>> GetCommentsAsync(int id)
        {
            return Client.GetAsync<List<CommentDto>>($"{id}/comments");
        }
    }

    // TODO: VC: Do this later

    public class TodosControllerClient : BaseControllerClient
    {
        public TodosControllerClient(IControllerClientFactory clientFactory) 
            : base(clientFactory, "todos")
        {
        }
    }

    public class PostDto
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

    public class CommentDto
    {
        public int PostId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Body { get; set; }
    }
}
