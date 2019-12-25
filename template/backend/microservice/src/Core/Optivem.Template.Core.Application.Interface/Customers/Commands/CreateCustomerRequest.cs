using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerRequest : IRequest<CustomerResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}