using Xunit;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class ClientFixture<TClient> : IClassFixture<TClient>
        where TClient : class
    {
        public ClientFixture(TClient client)
        {
            Client = client;
        }

        protected TClient Client { get; private set; }

    }
}
