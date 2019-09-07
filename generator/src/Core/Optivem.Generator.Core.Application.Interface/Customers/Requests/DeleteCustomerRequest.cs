using Optivem.Framework.Core.Application;

namespace Optivem.Generator.Core.Application.Customers.Requests
{
    public class DeleteCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}