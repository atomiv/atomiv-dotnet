using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Optivem.Common;
using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.Test.Configuration;
using System;
using System.Net.Http;

namespace Optivem.Test.AspNetCore
{
    public class WebTestClient : IDisposable
    {
        public WebTestClient(IConfigurationRoot configurationRoot, TestServer testServer, HttpClient httpClient, IControllerClientFactory controllerClientFactory)
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
    }
}