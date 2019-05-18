using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;
using System;
using System.Net.Http;

namespace Optivem.Test.Xunit.AspNetCore
{
    public abstract class BaseClient<TStartup> : IDisposable where TStartup : class
    {
        public BaseClient()
        {
            var webHostBuilder = CreateWebHostBuilder();
            TestServer = new TestServer(webHostBuilder);
            HttpClient = TestServer.CreateClient();
            Client = new Client(HttpClient);
            ControllerClientFactory = CreateControllerClientFactory();
        }

        protected TestServer TestServer { get; }

        protected HttpClient HttpClient { get; }

        protected IClient Client { get; }

        protected IControllerClientFactory ControllerClientFactory { get; private set; }

        public void Dispose()
        {
            TestServer.Dispose();
            HttpClient.Dispose();
        }

        protected virtual IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseStartup<TStartup>();
        }

        protected abstract IControllerClientFactory CreateControllerClientFactory();


    }
}
