using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.UI.Clients
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
