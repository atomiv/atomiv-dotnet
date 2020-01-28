using Optivem.Atomiv.Core.Common.Http;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class BaseApiClient
    {
        public BaseApiClient(IControllerClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IControllerClientFactory ClientFactory { get; private set; }
    }
}