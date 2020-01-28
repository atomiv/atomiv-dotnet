using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class ListCustomersQuery : IRequest<ListCustomersQueryResponse>
    {
        public int Limit { get; set; }

        public string NameSearch { get; set; }
    }
}