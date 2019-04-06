using Optivem.Platform.Test.Xunit.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Platform.Web.AspNetCore.Rest.Test
{
    public class ValuesControllerTest : RestTestServerFixtureTest
    {
        public ValuesControllerTest(RestTestServerFixture testServerFixture) 
            : base(testServerFixture)
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

            var actual = await TestServerFixture.ValuesControllerClient.GetCollectionAsync();

            AssertUtilities.AssertEqual(expected, actual);
        }
    }
}
