using Optivem.Framework.Test.Xunit.Web.AspNetCore;

namespace Optivem.Framework.Web.AspNetCore.Rest.Test
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
