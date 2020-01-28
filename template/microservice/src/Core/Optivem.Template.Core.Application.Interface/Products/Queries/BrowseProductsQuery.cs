using Optivem.Atomiv.Core.Application;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class BrowseProductsQuery : IRequest<BrowseProductsQueryResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}