using Optivem.Common.Http;
using Optivem.Test.Xunit.AspNetCore;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Web.AspNetCore.Test
{
    public class ExceptionsControllerTest : ClientFixture<Client>
    {
        public ExceptionsControllerTest(Client client)
            : base(client)
        {
        }

        [Fact]
        public async Task TestGetAsyncReturnsInternalServerError()
        {
            var exception = await Assert.ThrowsAsync<ProblemDetailsClientException>(async () => await Client.Exceptions.GetAsync(500));
            Assert.Equal(HttpStatusCode.InternalServerError, exception.StatusCode);
        }

        [Fact]
        public async Task TestGetAsyncReturnsBadRequestError()
        {
            var exception = await Assert.ThrowsAsync<ProblemDetailsClientException>(async () => await Client.Exceptions.GetAsync(400));
            Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        }
    }
}
