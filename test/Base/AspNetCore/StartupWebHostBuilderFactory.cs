using Microsoft.AspNetCore.Hosting;
using Optivem.Atomiv.Core.Common;

namespace Optivem.Atomiv.Test.AspNetCore
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