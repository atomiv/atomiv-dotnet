using Optivem.Framework.Core.Common.Http;

namespace Optivem.Framework.Infrastructure.AspNetCore
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
