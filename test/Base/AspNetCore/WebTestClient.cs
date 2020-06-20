using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Atomiv.Core.Common.Http;
using System;
using System.Net.Http;

namespace Atomiv.Test.AspNetCore
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

    // TODO: VC: Check if needed

    /*
     *
        public WebDbTestClient(IConfigurationRoot configurationRoot, WebTestClient webTestClient, DbTestClient<TDbContext> databaseTestClient)
        {
            ConfigurationRoot = configurationRoot;
            WebTestClient = webTestClient;
            DatabaseTestClient = databaseTestClient;
        }

        public IConfigurationRoot ConfigurationRoot { get; private set; }

        public WebTestClient WebTestClient { get; private set; }

        public DbTestClient<TDbContext> DatabaseTestClient { get; private set; }

        public IControllerClientFactory ControllerClientFactory => WebTestClient.ControllerClientFactory;

        public IControllerClient CreateControllerClient(string controllerUri)
        {
            return WebTestClient.CreateControllerClient(controllerUri);
        }

        public TDbContext CreateDatabaseContext()
        {
            return DatabaseTestClient.CreateContext();
        }

        public void Dispose()
        {
            WebTestClient.Dispose();

            // TODO: VC: Check if need to delete
            // DatabaseTestClient.EnsureDatabaseDeleted();
        }
    }
     *
     *
     */
}