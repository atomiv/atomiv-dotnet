using Xunit;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class TestClientFixture<TClient> : IClassFixture<TClient>
        where TClient : class
    {
        public TestClientFixture(TClient client)
        {
            Client = client;
        }

        protected TClient Client { get; private set; }

    }
}
