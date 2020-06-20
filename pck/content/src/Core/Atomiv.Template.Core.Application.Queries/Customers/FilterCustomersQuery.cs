using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Queries.Customers
{
    public class FilterCustomersQuery : IRequest<FilterCustomersQueryResponse>
    {
        public int Limit { get; set; }

        public string NameSearch { get; set; }
    }
}