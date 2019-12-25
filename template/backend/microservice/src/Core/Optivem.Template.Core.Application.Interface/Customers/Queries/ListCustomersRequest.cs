using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class ListCustomersRequest : IRequest<ListCustomersResponse>
    {
        public string NameSearch { get; set; }

        public int Limit { get; set; }
    }
}