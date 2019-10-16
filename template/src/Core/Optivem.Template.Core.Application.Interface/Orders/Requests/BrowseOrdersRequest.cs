using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class BrowseOrdersRequest : ICollectionRequest<BrowseOrdersResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
