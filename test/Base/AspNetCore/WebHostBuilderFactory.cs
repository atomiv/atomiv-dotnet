using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Test.AspNetCore
{
    public static class WebHostBuilderFactory
    {
        public static IWebHostBuilder Create(IFactory<IWebHostBuilder> webHostBuilderFactory)
        {
            return webHostBuilderFactory.Create();
        }

        public static IWebHostBuilder Create<TStartup>(IConfigurationRoot configurationRoot) where TStartup : class
        {
            var webHostBuilderFactory = new ConfiguredWebHostBuilderFactory<TStartup>(configurationRoot);
            return Create(webHostBuilderFactory);
        }
    }
}
