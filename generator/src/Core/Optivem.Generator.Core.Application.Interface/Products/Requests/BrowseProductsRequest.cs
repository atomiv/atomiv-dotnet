using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Products.Requests
{
    public class BrowseProductsRequest : ICollectionRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
