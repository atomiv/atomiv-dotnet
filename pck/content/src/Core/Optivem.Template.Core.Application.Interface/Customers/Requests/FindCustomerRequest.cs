using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class FindCustomerRequest : IRequest<FindCustomerResponse>
    {
        public int Id { get; set; }
    }
}