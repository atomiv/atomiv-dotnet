using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Domain.Products;

namespace Optivem.Generator.Core.Application.Products.UseCases
{
    public class BrowseProductsUseCase : BrowseAggregatesUseCase<IProductRepository, BrowseProductsRequest, BrowseProductsResponse, BrowseProductsRecordResponse, Product, ProductIdentity, int>
    {
        public BrowseProductsUseCase(IUseCaseMapper mapper, IProductRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}
