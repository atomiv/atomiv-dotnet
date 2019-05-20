using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers
{
    public class CreateCustomerRequest : ICreateRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
