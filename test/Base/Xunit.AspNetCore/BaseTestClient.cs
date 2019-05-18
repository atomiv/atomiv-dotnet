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
    public abstract class BaseTestClient<TStartup> : IDisposable where TStartup : class
    {
        public BaseTestClient()
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
                .UseStartup<TStartup>()
                ; // TODO: VC: Use test configuration

            // TODO: VC: Check fill up test DB with standard test data
        }

        protected abstract IControllerClientFactory CreateControllerClientFactory();


    }
}
