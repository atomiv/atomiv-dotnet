using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
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
        private const string JsonFileName = "appsettings.Test.json";

        public BaseTestClient()
        {
            var webHostBuilder = GetWebHostBuilder();
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

        protected virtual IWebHostBuilder GetWebHostBuilder()
        {
            var configurationBuilder = GetConfigurationBuilder();

            var configuration = configurationBuilder.Build();

            Setup(configuration);

            return new WebHostBuilder()
                .UseStartup<TStartup>()
                .UseConfiguration(configuration);

            // TODO: VC: Check fill up test DB with standard test data
        }

        protected virtual IConfigurationBuilder GetConfigurationBuilder()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(JsonFileName);

            return configurationBuilder;
        }

        protected abstract void Setup(IConfigurationRoot configuration);

        protected abstract IControllerClientFactory CreateControllerClientFactory();


    }
}
