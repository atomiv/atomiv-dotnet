using Atomiv.Core.Application;

namespace Generator.Core.Application.Orders.Requests
{
    public class BrowseOrdersRequest : ICollectionRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
