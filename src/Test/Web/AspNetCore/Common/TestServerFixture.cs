using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Optivem.Platform.Test.Common.Xunit.AspNetCore
{
    public class TestServerFixture : IDisposable
    {
        public TestServerFixture(IWebHostBuilder webHostBuilder)
        {
            TestServer = new TestServer(webHostBuilder);
            HttpClient = TestServer.CreateClient();
        }

        public TestServer TestServer { get; }

        public HttpClient HttpClient { get; }

        public void Dispose()
        {
            TestServer.Dispose();
            HttpClient.Dispose();
        }
    }
}
