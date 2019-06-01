using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers
{
    public class FindCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}