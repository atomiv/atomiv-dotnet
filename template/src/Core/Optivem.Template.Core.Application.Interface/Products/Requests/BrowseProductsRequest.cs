using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Products.Responses;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class BrowseProductsRequest : ICollectionRequest<BrowseProductsResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
