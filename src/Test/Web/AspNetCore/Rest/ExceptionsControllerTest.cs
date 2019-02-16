using Optivem.Platform.Core.Common.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task TestGetAsync()
        {
            await Assert.ThrowsAsync<RestClientException>(async () => await TestServerFixture.ExceptionsControllerClient.GetAsync(500));

            // AssertUtilities.AssertEqual(expected, actual);
        }
    }
}
