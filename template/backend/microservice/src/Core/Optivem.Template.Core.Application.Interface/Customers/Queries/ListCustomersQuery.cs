using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class ListCustomersQuery : IRequest<ListCustomersQueryResponse>
    {
        public int Limit { get; set; }

        public string NameSearch { get; set; }
    }
}