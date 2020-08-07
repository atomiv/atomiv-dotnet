using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Queries.Orders
{
    public class BrowseOrdersQuery : IQuery<BrowseOrdersQueryResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}