
using Optivem.Template.Web.UI.Clients;

namespace Optivem.Template.Web.UI.Services
{
    // TODO: VC: Consider moving into framework

    public class BaseService
    {
        public BaseService(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
}
