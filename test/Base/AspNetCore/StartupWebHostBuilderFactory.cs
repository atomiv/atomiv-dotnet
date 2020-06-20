using Microsoft.AspNetCore.Hosting;
using Atomiv.Core.Common;

namespace Atomiv.Test.AspNetCore
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