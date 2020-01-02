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

        Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);

        Task<FindProductResponse> FindProductAsync(FindProductRequest request);

        Task<ListProductsResponse> ListProductsAsync(ListProductRequest request);

        Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request);

        Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request);

        Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request);
    }
}