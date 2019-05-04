using Optivem.Common.Http;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Framework.Web.AspNetCore.Rest.Test
{
    public class ExceptionsControllerTest : RestTestServerFixtureTest
    {
        public ExceptionsControllerTest(RestTestServerFixture testServerFixture)
            : base(testServerFixture)
        {
        }

        [Fact]
        public async Task TestGetAsyncReturnsInternalServerError()
        {
            var exception = await Assert.ThrowsAsync<RestClientException>(async () => await TestServerFixture.ExceptionsControllerClient.GetAsync(500));
            Assert.Equal(HttpStatusCode.InternalServerError, exception.StatusCode);
        }

        [Fact]
        public async Task TestGetAsyncReturnsBadRequestError()
        {
            var exception = await Assert.ThrowsAsync<RestClientException>(async () => await TestServerFixture.ExceptionsControllerClient.GetAsync(400));
            Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        }
    }
}
