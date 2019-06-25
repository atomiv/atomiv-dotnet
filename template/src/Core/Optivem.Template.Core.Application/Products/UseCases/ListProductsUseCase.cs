using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products
{
    public class ListProductsUseCase : ListAggregatesUseCase<IProductRepository, ListProductsRequest, ListProductsResponse, ListProductsRecordResponse, Product, ProductIdentity, int>
    {
        public ListProductsUseCase(IProductRepository repository, ICollectionResponseMapper<Product, ListProductsResponse> responseMapper)
            : base(repository, responseMapper)
        {
        }
    }
}
