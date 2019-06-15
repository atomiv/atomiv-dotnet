using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Customers.Requests
{
    public class CreateCustomerRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}