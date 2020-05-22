using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Queries.Orders
{
    public class BrowseOrdersQuery : IRequest<BrowseOrdersQueryResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}