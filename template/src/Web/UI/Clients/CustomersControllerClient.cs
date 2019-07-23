using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.Clients
{
    public class CustomersControllerClient : BaseContentControllerClient
    {
        public CustomersControllerClient(IContentControllerClientFactory clientFactory) 
            : base(clientFactory, "api/customers")
        {
        }

        public Task<ListCustomersResponse> ListCustomers(ListCustomersRequest request)
        {
            return Client.GetAsync<ListCustomersRequest, ListCustomersResponse>(request);
        }
    }
}
