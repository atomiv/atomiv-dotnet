using Atomiv.Core.Common.Http;

namespace Atomiv.Infrastructure.AspNetCore
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