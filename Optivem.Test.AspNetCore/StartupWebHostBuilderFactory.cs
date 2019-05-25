using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Optivem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.AspNetCore
{
    public class StartupWebHostBuilderFactory<TStartup> : IFactory<IWebHostBuilder> where TStartup : class
    {
        public IWebHostBuilder Create()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<TStartup>();

            return webHostBuilder;
        }
    }
}
