using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Customers
{
    public class FindCustomerRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}