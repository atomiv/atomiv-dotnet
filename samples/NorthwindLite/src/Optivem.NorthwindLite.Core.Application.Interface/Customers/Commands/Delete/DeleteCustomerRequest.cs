using Optivem.Core.Application;

namespace Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands
{
    public class DeleteCustomerRequest : IDeleteRequest<int>
    {
        public int Id { get; set; }
    }
}