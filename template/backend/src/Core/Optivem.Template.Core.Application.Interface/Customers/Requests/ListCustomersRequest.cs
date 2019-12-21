using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class ListCustomersRequest : IRequest<ListCustomersResponse>
    {
        public string NameSearch { get; set; }

        public int Limit { get; set; }
    }
}