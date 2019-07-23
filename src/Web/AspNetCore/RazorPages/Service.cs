using Optivem.Framework.Core.Common.Http;

namespace Optivem.Framework.Web.AspNetCore.RazorPages
{
    public class Service
    {
        public Service(IControllerClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IControllerClientFactory ClientFactory { get; set; }
    }
}
