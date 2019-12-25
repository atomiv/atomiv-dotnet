using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class BrowseProductsRequest : IRequest<BrowseProductsResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}