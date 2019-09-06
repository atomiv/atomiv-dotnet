using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class BrowseProductsUseCase : BrowseAggregatesUseCase<IProductRepository, BrowseProductsRequest, BrowseProductsResponse, BrowseProductsRecordResponse, Product, ProductIdentity, int>
    {
        public BrowseProductsUseCase(IProductRepository repository, ICollectionResponseMapper<Product, BrowseProductsResponse> responseMapper)
            : base(repository, responseMapper)
        {
        }
    }
}
