using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Customers.Requests
{
    public class FindCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}