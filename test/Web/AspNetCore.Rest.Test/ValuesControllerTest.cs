using Optivem.Test.Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Web.AspNetCore.Test
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

            var actual = await TestServerFixture.Client.Values.GetCollectionAsync();

            AssertUtilities.AssertEqual(expected, actual);
        }
    }
}
