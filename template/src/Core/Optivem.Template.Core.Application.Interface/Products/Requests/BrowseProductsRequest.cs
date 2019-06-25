using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Products
{
    public class BrowseProductsRequest : IRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
