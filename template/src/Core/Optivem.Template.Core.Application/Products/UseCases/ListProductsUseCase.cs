using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class ListProductsUseCase : ListAggregatesUseCase<IProductRepository, ListProductsRequest, ListProductsResponse, ListProductsRecordResponse, Product, ProductIdentity, int>
    {
        public ListProductsUseCase(IMapper mapper, IProductRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}
