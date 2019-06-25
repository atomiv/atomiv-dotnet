using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products.Entities;
using Optivem.Template.Core.Domain.Products.Repositories;
using Optivem.Template.Core.Domain.Products.ValueObjects;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class ListProductsUseCase : ListAggregatesUseCase<IProductRepository, ListProductsRequest, ListProductsResponse, ListProductsRecordResponse, Product, ProductIdentity, int>
    {
        public ListProductsUseCase(IProductRepository repository, ICollectionResponseMapper<Product, ListProductsResponse> responseMapper)
            : base(repository, responseMapper)
        {
        }
    }
}
