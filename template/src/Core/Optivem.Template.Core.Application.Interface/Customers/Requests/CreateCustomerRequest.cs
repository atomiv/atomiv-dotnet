using Optivem.Framework.Core.Common;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class CreateCustomerRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}