using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse, int>
    {
        public int Id { get; set; }
    }
}