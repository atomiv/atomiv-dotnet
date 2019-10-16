using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}