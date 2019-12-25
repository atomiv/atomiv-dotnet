using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class BrowseOrdersRequest : IRequest<BrowseOrdersResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}