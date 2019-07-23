using Optivem.Framework.Core.Common.Http;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class BaseContentControllerClient
    {
        private BaseContentControllerClient(IContentControllerClient client)
        {
            Client = client;
        }

        public BaseContentControllerClient(IContentControllerClientFactory clientFactory, string controllerUri)
            : this(clientFactory.Create(controllerUri)) { }

        public IContentControllerClient Client { get; private set; }
    }
}
