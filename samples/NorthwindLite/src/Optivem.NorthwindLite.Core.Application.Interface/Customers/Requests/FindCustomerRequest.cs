using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Customers.Requests
{
    public class FindCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}