using Optivem.Framework.Test.Xunit;
using Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fixture;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest
{
    public class ExceptionsControllerTest : FixtureTest<TestClient>
    {
        public ExceptionsControllerTest(TestClient client)
            : base(client)
        {
        }

        [Fact]
        public async Task TestGetAsyncReturnsInternalServerError()
        {
            var response = await Fixture.Exceptions.GetAsync(500);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task TestGetAsyncReturnsBadRequestError()
        {
            var response = await Fixture.Exceptions.GetAsync(400);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}