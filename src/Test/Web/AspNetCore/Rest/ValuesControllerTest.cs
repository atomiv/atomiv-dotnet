using Optivem.Platform.Test.Common;
using Optivem.Platform.Test.Web.AspNetCore.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest
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
