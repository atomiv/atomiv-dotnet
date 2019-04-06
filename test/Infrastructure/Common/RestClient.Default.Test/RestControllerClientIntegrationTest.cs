using Optivem.Platform.Test.Xunit.Common;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Platform.Infrastructure.Common.RestClient.Default.Test
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
            var expected = new Post
            {
                Id = 1,
                UserId = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
            };

            var actual = await JsonPlaceholderClient.Posts.GetAsync(1);

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public async Task TestGetCollectionAsync()
        {
            var actual = await JsonPlaceholderClient.Posts.GetCollectionAsync();
            
            var expectedCount = 100;
            var actualCount = actual.Count();

            Assert.Equal(expectedCount, actualCount);

            var expectedFirst = new Post
            {
                Id = 1,
                UserId = 1,
                Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
            };

            var actualFirst = actual.First();

            AssertUtilities.AssertEqual(expectedFirst, actualFirst);

            var expectedLast = new Post
            {
                Id = 100,
                UserId = 10,
                Title = "at nam consequatur ea labore ea harum",
                Body = "cupiditate quo est a modi nesciunt soluta\nipsa voluptas error itaque dicta in\nautem qui minus magnam et distinctio eum\naccusamus ratione error aut",
            };

            var actualLast = actual.Last();

            AssertUtilities.AssertEqual(expectedLast, actualLast);
        }

        [Fact]
        public async Task TestPostAsync()
        {
            var request = new Post
            {
                UserId = 2,
                Title = "Some Title",
                Body = "Some Body",
            };

            var actual = await JsonPlaceholderClient.Posts.PostAsync(request);

            Assert.True(actual.Id > 0);

            Assert.Equal(2, actual.UserId);
            Assert.Equal("Some Title", actual.Title);
            Assert.Equal("Some Body", actual.Body);
        }

        [Fact]
        public async Task TestPutAsync()
        {
            var expected = await JsonPlaceholderClient.Posts.GetAsync(7);
            expected.UserId = 10;
            expected.Title = "Some Title";
            expected.Body = "Some Body";

            var actual = await JsonPlaceholderClient.Posts.PutAsync(7, expected);

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact(Skip = "Checking test failure")]
        public async Task TestPatchAsync()
        {
            var expected = await JsonPlaceholderClient.Posts.GetAsync(5);
            expected.Title = "Some Title";

            var request = new Post
            {
                Title = "Some Title",
            };

            var actual = await JsonPlaceholderClient.Posts.PutAsync(5, request);

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public async Task TestDeleteAsync()
        {
            await JsonPlaceholderClient.Posts.DeleteAsync(8);
        }


        // TODO: VC: Requests

        /*
         * 
         * 
GET	/posts/1/comments
GET	/comments?postId=1
GET	/posts?userId=1
         * 
         */

    }
}
