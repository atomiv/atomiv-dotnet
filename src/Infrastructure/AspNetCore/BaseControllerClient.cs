using Optivem.Atomiv.Core.Common.Http;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class BaseControllerClient
    {
        private BaseControllerClient(IControllerClient client)
        {
            Client = client;
        }

        public BaseControllerClient(IControllerClientFactory clientFactory, string controllerUri)
            : this(clientFactory.Create(controllerUri)) { }

        public IControllerClient Client { get; private set; }
    }
}