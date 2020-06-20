using Atomiv.Core.Application;

namespace Generator.Core.Application.Customers.Requests
{
    public class DeleteCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}