using Newtonsoft.Json;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Platform.Infrastructure.Core.RestClient.Default.Test.Integration
{
    public class RestControllerClientIntegrationTest
    {
        [Fact]
        public async Task TestGetAsyncId()
        {
            var client = new RestControllerClient("https://jsonplaceholder.typicode.com/todos");

            var actual = await client.GetAsync<TodoDto>(1);

            var expected = new TodoDto
            {
                Id = 1,
                UserId = 1,
                Title = "delectus aut autem",
                Completed = false,
            };

            AssertEqual(expected, actual);
        }

        private class TodoDto
        {
            public int Id { get; set; }

            public int UserId { get; set; }

            public string Title { get; set; }

            public bool Completed { get; set; }
        }

        // TODO: VC: Remove dependency on Newtonsoft.Json

        private static void AssertEqual<T>(T expected, T actual)
        {
            var expectedString = JsonConvert.SerializeObject(expected, Formatting.Indented);
            var actualString = JsonConvert.SerializeObject(actual, Formatting.Indented);

            Assert.Equal(expectedString, actualString);
        }
    }
}
