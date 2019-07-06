using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Framework.Infrastructure.NewtonsoftJson;
using Optivem.Framework.Infrastructure.System.Reflection;
using Optivem.Framework.Test.MicrosoftExtensions.Configuration;
using System;

namespace Optivem.Framework.Test.AspNetCore
{
    public static class WebTestClientFactory
    {
        public static WebTestClient Create(IConfigurationRoot configurationRoot,
            IWebHostBuilder webHostBuilder,
            Func<IClient, IControllerClientFactory> createControllerClientFactory)
        {
            var testServer = new TestServer(webHostBuilder);
            var httpClient = testServer.CreateClient();
            var client = new Client(httpClient);
            var controllerClientFactory = createControllerClientFactory(client);

            return new WebTestClient(configurationRoot, testServer, httpClient, controllerClientFactory);
        }

        public static WebTestClient Create<TStartup>(IConfigurationRoot configurationRoot) where TStartup : class
        {
            var webHostBuilder = WebHostBuilderFactory.Create<TStartup>(configurationRoot);

            var jsonSerializationService = new JsonSerializationService();
            var propertyFactory = new PropertyFactory();
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
