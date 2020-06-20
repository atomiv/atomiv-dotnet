using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Atomiv.Core.Common;

namespace Atomiv.Test.AspNetCore
{
    public class ConfiguredWebHostBuilderFactory<TStartup> : IFactory<IWebHostBuilder> where TStartup : class
    {
        public ConfiguredWebHostBuilderFactory(IConfigurationRoot configurationRoot)
        {
            ConfigurationRoot = configurationRoot;
        }

        public IConfigurationRoot ConfigurationRoot { get; private set; }

        public IWebHostBuilder Create()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<TStartup>()
                .UseConfiguration(ConfigurationRoot);

            return webHostBuilder;
        }
    }
}