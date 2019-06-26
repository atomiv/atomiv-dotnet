using Optivem.Framework.Test.Xunit;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Framework.Infrastructure.AspNetCore.IntegrationTest
{
    public class RestControllerClientIntegrationTest : JsonPlaceholderClientFixtureTest
    {
        public RestControllerClientIntegrationTest(JsonPlaceholderClientFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var expected = new PostDto
            {
                Id = 1,
                UserId = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
            };

            var actual = await JsonPlaceholderClient.Posts.GetAsync(1);

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            AssertUtilities.AssertEqual(expected, actual.Data);
        }

        [Fact]
        public async Task TestGetCollectionAsync()
        {
            var actual = await JsonPlaceholderClient.Posts.GetAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var expectedCount = 100;
            var actualCount = actual.Data.Count();

            Assert.Equal(expectedCount, actualCount);

            var expectedFirst = new PostDto
            {
                Id = 1,
                UserId = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
            };

            var actualFirst = actual.Data.First();

            AssertUtilities.AssertEqual(expectedFirst, actualFirst);

            var expectedLast = new PostDto
            {
                Id = 100,
                UserId = 10,
                Title = "at nam consequatur ea labore ea harum",
                Body = "cupiditate quo est a modi nesciunt soluta\nipsa voluptas error itaque dicta in\nautem qui minus magnam et distinctio eum\naccusamus ratione error aut",
            };

            var actualLast = actual.Data.Last();

            AssertUtilities.AssertEqual(expectedLast, actualLast);
        }

        [Fact]
        public async Task TestPostAsync()
        {
            var request = new PostDto
            {
                UserId = 2,
                Title = "Some Title",
                Body = "Some Body",
            };

            var actual = await JsonPlaceholderClient.Posts.CreateAsync(request);

            Assert.Equal(HttpStatusCode.Created, actual.StatusCode);

            var actualContent = actual.Data;

            Assert.True(actualContent.Id > 0);

            Assert.Equal(2, actualContent.UserId);
            Assert.Equal("Some Title", actualContent.Title);
            Assert.Equal("Some Body", actualContent.Body);
        }

        [Fact]
        public async Task TestPutAsync()
        {
            var expected = await JsonPlaceholderClient.Posts.GetAsync(7);

            Assert.Equal(HttpStatusCode.OK, expected.StatusCode);

            var expectedContent = expected.Data;

            expectedContent.UserId = 10;
            expectedContent.Title = "Some Title";
            expectedContent.Body = "Some Body";

            var actual = await JsonPlaceholderClient.Posts.PutAsync(7, expectedContent);

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Data;

            AssertUtilities.AssertEqual(expectedContent, actualContent);
        }

        [Fact(Skip = "Checking test failure")]
        public async Task TestPatchAsync()
        {
            var expected = await JsonPlaceholderClient.Posts.GetAsync(5);

            Assert.Equal(HttpStatusCode.OK, expected.StatusCode);

            var expectedContent = expected.Data;

            expectedContent.Title = "Some Title";

            var request = new PostDto
            {
                Title = "Some Title",
            };

            var actual = await JsonPlaceholderClient.Posts.PutAsync(5, request);

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Data;

            AssertUtilities.AssertEqual(expectedContent, actualContent);
        }

        [Fact]
        public async Task TestDeleteAsync()
        {
            await JsonPlaceholderClient.Posts.DeleteAsync(8);
        }

        [Fact]
        public async Task TestGetByQueryParamRawAsync()
        {
            var actual = await JsonPlaceholderClient.Posts.GetByUserIdRawAsync(1);
        }

        [Fact]
        public async Task TestGetByQueryParamAsync()
        {
            var actual = await JsonPlaceholderClient.Posts.GetByUserIdAsync(1);
        }

        [Fact]
        public async Task TestGetSubresources()
        {
            var actual = await JsonPlaceholderClient.Posts.GetCommentsRawAsync(1);
        }
    }
}