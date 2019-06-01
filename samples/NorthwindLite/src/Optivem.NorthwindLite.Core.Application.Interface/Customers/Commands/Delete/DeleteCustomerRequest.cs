using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands
{
    public class DeleteCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}