using Atomiv.Core.Application;

namespace Generator.Core.Application.Products.Requests
{
    public class BrowseProductsRequest : ICollectionRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
