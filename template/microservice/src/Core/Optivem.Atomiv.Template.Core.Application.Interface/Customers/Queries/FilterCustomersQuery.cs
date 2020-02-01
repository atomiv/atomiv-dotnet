using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class FilterCustomersQuery : IRequest<FilterCustomersQueryResponse>
    {
        public int Limit { get; set; }

        public string NameSearch { get; set; }
    }
}