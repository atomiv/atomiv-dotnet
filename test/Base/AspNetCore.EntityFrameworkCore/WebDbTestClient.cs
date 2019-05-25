using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optivem.Common.Http;
using Optivem.Test.EntityFrameworkCore;
using System;

namespace Optivem.Test.AspNetCore.EntityFrameworkCore
{
    public class WebDbTestClient<TDbContext> : IDisposable
        where TDbContext : DbContext
    {
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
            return DatabaseTestClient.ContextFactory.Create();
        }

        public void EnsureDatabaseCreated()
        {
            DatabaseTestClient.EnsureDatabaseCreated();
        }

        public void EnsureDatabaseDeleted()
        {
            DatabaseTestClient.EnsureDatabaseDeleted();
        }

        public void Dispose()
        {
            WebTestClient.Dispose();
        }



    }
}
