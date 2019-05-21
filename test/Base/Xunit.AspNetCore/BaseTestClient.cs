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
        private const string DefaultJsonFileName = "appsettings.Test.json";

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
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<TStartup>();

            var configurationJsonFile = GetConfigurationJsonFile();

            if(configurationJsonFile == null)
            {
                return webHostBuilder;
            }

            var configurationBuilder = GetConfigurationBuilder(configurationJsonFile);
            var configuration = configurationBuilder.Build();

            Setup(configuration);

            return webHostBuilder
                .UseConfiguration(configuration);

            // TODO: VC: Check fill up test DB with standard test data
        }

        protected virtual string GetConfigurationJsonFile()
        {
            return DefaultJsonFileName;
        }

        protected virtual IConfigurationBuilder GetConfigurationBuilder(string file)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(file);

            return configurationBuilder;
        }

        protected abstract void Setup(IConfigurationRoot configuration);

        protected abstract IControllerClientFactory CreateControllerClientFactory();


    }
}
