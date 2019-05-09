using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using System;
using System.Net.Http;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class TestServerFixture : IDisposable
    {
        public TestServerFixture(IWebHostBuilder webHostBuilder, ISerializationService serializationService)
        {
            TestServer = new TestServer(webHostBuilder);
            HttpClient = TestServer.CreateClient();
            ServiceClient = new RestServiceClient(serializationService, HttpClient);
        }

        public TestServerFixture(IWebHostBuilder webHostBuilder)
            : this(webHostBuilder, new SerializationService()) { }

        public TestServer TestServer { get; }

        public RestServiceClient ServiceClient { get; }

        public HttpClient HttpClient { get; }

        public ISerializationService SerializationService { get; }

        public void Dispose()
        {
            TestServer.Dispose();
            HttpClient.Dispose();
        }
    }

    public class TestServerFixture<T> : TestServerFixture where T : class
    {
        public TestServerFixture(ISerializationService serializationService) 
            : base(CreateWebHostBuilder(), serializationService)
        {
        }

        public TestServerFixture()
            : this(new SerializationService()) { }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseStartup<T>();
        }
    }
}
