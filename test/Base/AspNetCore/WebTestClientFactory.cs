using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Infrastructure.NewtonsoftJson;
using Optivem.Atomiv.Infrastructure.System.Reflection;
using Optivem.Atomiv.Test.MicrosoftExtensions.Configuration;
using System;

namespace Optivem.Atomiv.Test.AspNetCore
{
    public static class WebTestClientFactory
    {
        public static WebTestClient Create(IConfigurationRoot configurationRoot,
            IWebHostBuilder webHostBuilder,
            Func<IClient, IControllerClientFactory> createControllerClientFactory)
        {
            var testServer = new TestServer(webHostBuilder);
            var httpClient = testServer.CreateClient();
            var client = new WebClient(httpClient);
            var controllerClientFactory = createControllerClientFactory(client);

            return new WebTestClient(configurationRoot, testServer, httpClient, controllerClientFactory);
        }

        public static WebTestClient Create<TStartup>(IConfigurationRoot configurationRoot) where TStartup : class
        {
            var webHostBuilder = WebHostBuilderFactory.Create<TStartup>(configurationRoot);

            var jsonSerializationService = new JsonSerializer();
            var propertyFactory = new PropertyMapper();
            Func<IClient, IControllerClientFactory> createControllerClientFactory = e => new JsonControllerClientFactory(e, jsonSerializationService, propertyFactory);
            return Create(configurationRoot, webHostBuilder, createControllerClientFactory);
        }

        public static WebTestClient Create<TStartup>() where TStartup : class
        {
            var configurationRoot = ConfigurationRootFactory.Create();
            return Create<TStartup>(configurationRoot);
        }
    }
}