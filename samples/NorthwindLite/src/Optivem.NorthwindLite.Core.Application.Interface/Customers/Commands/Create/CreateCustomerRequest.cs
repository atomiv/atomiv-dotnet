using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers
{
    public class CreateCustomerRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}