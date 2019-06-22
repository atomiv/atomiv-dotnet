using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Customers
{
    public class DeleteCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}