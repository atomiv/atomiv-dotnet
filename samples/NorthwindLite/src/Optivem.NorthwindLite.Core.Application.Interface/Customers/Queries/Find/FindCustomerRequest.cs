using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers
{
    public class FindCustomerRequest : IFindRequest<int>
    {
        public int Id { get; set; }
    }
}