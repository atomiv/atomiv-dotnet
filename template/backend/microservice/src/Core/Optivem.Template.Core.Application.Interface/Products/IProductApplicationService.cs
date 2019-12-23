using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
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