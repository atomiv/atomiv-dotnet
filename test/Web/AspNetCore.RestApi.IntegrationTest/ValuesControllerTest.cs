using Optivem.Atomiv.Test.Xunit;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fixture;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest
{
    public class ValuesControllerTest : FixtureTest<TestClient>
    {
        public ValuesControllerTest(TestClient client)
            : base(client)
        {
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var expected = new List<string>
            {
                "value1",
                "value2"
            };

            var actual = await Fixture.Values.GetAllAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            AssertUtilities.Equal(expected, actual.Data);
        }
    }
}