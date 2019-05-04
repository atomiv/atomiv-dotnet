using Optivem.Test.Xunit.AspNetCore;

namespace Optivem.Web.AspNetCore.Test
{
    // TODO: VC: This could be deleted and tests to directly inherit from TestServerFixtureTest

    public class RestTestServerFixtureTest : TestServerFixtureTest<RestTestServerFixture>
    {
        public RestTestServerFixtureTest(RestTestServerFixture testServerFixture) 
            : base(testServerFixture)
        {

        }

        
    }
}
