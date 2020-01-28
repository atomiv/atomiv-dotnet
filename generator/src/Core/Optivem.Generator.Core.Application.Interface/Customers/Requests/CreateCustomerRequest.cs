using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Customers.Requests
{
    public class CreateCustomerRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}