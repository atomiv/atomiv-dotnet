using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public interface IProductApplicationService : IApplicationService
    {
        Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request);

        Task<ProductResponse> CreateProductAsync(CreateProductRequest request);

        Task<FindProductResponse> FindProductAsync(Guid id);

        Task<ListProductsResponse> ListProductsAsync(ListProductRequest request);

        Task<ProductResponse> RelistProductAsync(Guid id);

        Task<ProductResponse> UnlistProductAsync(Guid id);

        Task<ProductResponse> UpdateProductAsync(UpdateProductRequest request);
    }
}