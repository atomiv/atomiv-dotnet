using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest
{
    public class TestServerHttpClientFactory : IHttpClientFactory
    {
        private readonly TestServer _testServer;

        public TestServerHttpClientFactory(TestServer testServer)
        {
            _testServer = testServer;
        }

        public HttpClient CreateClient(string name)
        {
            return _testServer.CreateClient();
        }
    }
}
