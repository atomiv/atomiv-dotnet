using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Infrastructure.Common.RestClient.Default;
using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using Optivem.Platform.Test.Web.AspNetCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

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
