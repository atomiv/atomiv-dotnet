using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Queries.Products
{
    public class BrowseProductsQuery : IQuery<BrowseProductsQueryResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}