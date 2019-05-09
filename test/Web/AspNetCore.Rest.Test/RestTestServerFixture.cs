using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Framework.Test.Web.AspNetCore.Rest.Fake;
using Optivem.Test.Xunit.AspNetCore;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Models;
using Optivem.Test.Xunit;
using Optivem.Web.AspNetCore.Rest.Test;

namespace Optivem.Web.AspNetCore.Test
{
    // TODO: VC: Consider moving into Fixtures folder

    public class RestTestServerFixture : TestServerFixture<Startup>
    {
        public RestTestServerFixture()
        {
            Client = new RestTestServiceClient(ServiceClient);
        }

        public RestTestServiceClient Client { get; }
    }



}
