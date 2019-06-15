using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class DeleteCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}