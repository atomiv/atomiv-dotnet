using Optivem.Framework.Core.Common.Http;

namespace Optivem.Framework.Web.AspNetCore.RazorPages
{
    public class ControllerService : Service
    {
        public ControllerService(IControllerClientFactory clientFactory, string controllerUri) 
            : base(clientFactory)
        {
            ControllerClient = clientFactory.Create(controllerUri);
        }

        public IControllerClient ControllerClient { get; private set; }
    }
}
