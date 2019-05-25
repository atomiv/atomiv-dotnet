using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Optivem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class DefaultWebHostBuilderFactory<TStartup> : IFactory<IWebHostBuilder> where TStartup : class
    {
        public DefaultWebHostBuilderFactory(IConfigurationRoot configurationRoot = null)
        {
            ConfigurationRoot = configurationRoot;
        }

        public DefaultWebHostBuilderFactory(IFactory<IConfigurationBuilder> configurationBuilderFactory)
            : this(configurationBuilderFactory.Create().Build()) { }

        public IConfigurationRoot ConfigurationRoot { get; private set; }

        public IWebHostBuilder Create()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<TStartup>();

            if(ConfigurationRoot != null)
            {
                webHostBuilder.UseConfiguration(ConfigurationRoot);
            }

            return webHostBuilder;
        }
    }
}
