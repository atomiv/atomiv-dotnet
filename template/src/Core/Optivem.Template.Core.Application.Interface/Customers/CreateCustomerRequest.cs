using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Customers
{
    public class CreateCustomerRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}