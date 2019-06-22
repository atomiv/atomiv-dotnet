using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Interface.Customers.Requests
{
    public class FindCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}