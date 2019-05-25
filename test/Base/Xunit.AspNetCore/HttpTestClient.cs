using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Optivem.Common;
using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;
using System;
using System.Net.Http;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class HttpTestClient : IDisposable
    {
        private HttpTestClient(IConfigurationRoot configurationRoot, TestServer testServer, HttpClient httpClient, IControllerClientFactory controllerClientFactory)
        {
            ConfigurationRoot = configurationRoot;
            TestServer = testServer;
            HttpClient = httpClient;
            ControllerClientFactory = controllerClientFactory;
        }

        public IConfigurationRoot ConfigurationRoot { get; private set; }

        public TestServer TestServer { get; }

        public HttpClient HttpClient { get; }

        public IControllerClientFactory ControllerClientFactory { get; private set; }

        public IControllerClient CreateControllerClient(string controllerUri)
        {
            return ControllerClientFactory.Create(controllerUri);
        }

        // TODO: VC: Consider moving into controller client factory

        public virtual void Dispose()
        {
            TestServer.Dispose();
            HttpClient.Dispose();
        }

        public static HttpTestClient Create(IFactory<IConfigurationBuilder> configurationBuilderFactory, 
            IFactory<IWebHostBuilder> webHostBuilderFactory,
            Func<IClient, IControllerClientFactory> createControllerClientFactory)
        {
            var configurationBuilder = configurationBuilderFactory.Create();
            var configurationRoot = configurationBuilder.Build();
            var webHostBuilder = webHostBuilderFactory.Create();

            var testServer = new TestServer(webHostBuilder);
            var httpClient = testServer.CreateClient();
            var client = new Client(httpClient);
            var controllerClientFactory = createControllerClientFactory(client);

            return new HttpTestClient(configurationRoot, testServer, httpClient, controllerClientFactory);
        }

        public static HttpTestClient CreateDefault<TStartup>()
            where TStartup : class
        {
            var configurationBuilderFactory = new DefaultConfigurationBuilderFactory();
            var webHostBuilderFactory = new DefaultWebHostBuilderFactory<TStartup>(configurationBuilderFactory);
            Func<IClient, IControllerClientFactory> createControllerClientFactory = e => new DefaultControllerClientFactory(e);
            return Create(configurationBuilderFactory, webHostBuilderFactory, createControllerClientFactory);
        }
    }
}