using Optivem.Core.Application;
using Optivem.Core.Application.Services;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.BrowseAll;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Core.Application
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IUseCaseMediator mediator) : base(mediator)
        {
        }

        public Task<ListCustomersResponse> ListCustomersAsync()
        {
            var request = new ListCustomersRequest();
            return Mediator.HandleAsync<ListCustomersRequest, ListCustomersResponse>(request);
        }
    }
}
