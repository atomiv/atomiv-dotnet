using Optivem.Platform.Test.Xunit.Web.AspNetCore;

namespace Optivem.Platform.Web.AspNetCore.Rest.Test
{
    public class RestTestServerFixtureTest : TestServerFixtureTest<RestTestServerFixture>
    {
        public RestTestServerFixtureTest(RestTestServerFixture testServerFixture) 
            : base(testServerFixture)
        {

        }

        
    }
}
