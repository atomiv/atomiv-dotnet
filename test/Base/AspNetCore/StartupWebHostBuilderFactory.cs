using Microsoft.AspNetCore.Hosting;
using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Test.AspNetCore
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
