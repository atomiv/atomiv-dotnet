using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using Generator.Core.Domain.Products;

namespace Generator.Core.Application.Products.UseCases
{
    public class BrowseProductsUseCase : BrowseAggregatesUseCase<IProductRepository, BrowseProductsRequest, BrowseProductsResponse, BrowseProductsRecordResponse, Product, ProductIdentity, int>
    {
        public BrowseProductsUseCase(IUseCaseMapper mapper, IProductRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}
