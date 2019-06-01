using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands
{
    public class UpdateCustomerResponse : IUpdateResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}