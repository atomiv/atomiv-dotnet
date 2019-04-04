using Optivem.Platform.Test.Common.Xunit.AspNetCore;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest
{
    public class RestTestServerFixtureTest : TestServerFixtureTest<RestTestServerFixture>
    {
        public RestTestServerFixtureTest(RestTestServerFixture testServerFixture) 
            : base(testServerFixture)
        {

        }

        
    }
}
