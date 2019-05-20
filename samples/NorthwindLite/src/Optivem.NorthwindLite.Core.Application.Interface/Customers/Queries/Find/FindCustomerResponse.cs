using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve
{
    public class FindCustomerResponse : IFindResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}