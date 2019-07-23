using Optivem.Framework.Core.Common.Http;

namespace Optivem.Template.Web.UI.Clients
{
    public class Client
    {
        public Client(IContentControllerClientFactory clientFactory)
        {
            Customers = new CustomersControllerClient(clientFactory);
        }

        public CustomersControllerClient Customers { get; }
    }
}
