using Optivem.Platform.Core.Common.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest
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
