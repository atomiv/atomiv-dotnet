using Optivem.Test.Xunit;
using Optivem.Test.Xunit.AspNetCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Web.AspNetCore.Test
{
    public class ValuesControllerTest : BaseTestFixture<TestClient>
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

            AssertUtilities.AssertEqual(expected, actual.Content);
        }
    }
}