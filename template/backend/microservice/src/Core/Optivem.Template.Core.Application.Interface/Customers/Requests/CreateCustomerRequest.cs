using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class CreateCustomerRequest : IRequest<CustomerResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}