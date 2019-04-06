using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
// using Serilog.Extensions.Logging.File;
using Serilog;

namespace Optivem.Platform.Test.Wed.AspNetCore.Rest.Fake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog((ctx, cfg) => 
                    cfg.ReadFrom.Configuration(ctx.Configuration)
                );
    }
}
