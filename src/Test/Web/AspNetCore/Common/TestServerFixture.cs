using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Platform.Test.Web.AspNetCore.Common
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
