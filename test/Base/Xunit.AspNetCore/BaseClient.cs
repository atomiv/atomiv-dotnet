using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
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
            var serializationService = CreateSerializationService();
            RestServiceClient = new RestServiceClient(serializationService, HttpClient);
        }

        protected TestServer TestServer { get; }

        protected RestServiceClient RestServiceClient { get; }

        protected HttpClient HttpClient { get; }

        protected ISerializationService SerializationService { get; }

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

        protected virtual ISerializationService CreateSerializationService()
        {
            return new SerializationService();
        }
    }
}
