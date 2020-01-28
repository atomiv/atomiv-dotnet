using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Customers.Requests
{
    public class UpdateCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}