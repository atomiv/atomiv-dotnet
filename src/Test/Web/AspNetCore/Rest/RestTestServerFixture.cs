using Microsoft.AspNetCore.Hosting;
using Optivem.Platform.Test.Web.AspNetCore.Common;
using Optivem.Platform.Test.Wed.AspNetCore.Rest.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest
{
    public class RestTestServerFixture : TestServerFixture
    {
        public RestTestServerFixture() 
            : base(CreateWebHostBuilder())
        {
        }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseStartup<Startup>();
        }
    }
}
