using Optivem.Framework.Core.Common;

namespace Optivem.Template.Core.Application.Customers.Responses
{
    public class UpdateCustomerResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}