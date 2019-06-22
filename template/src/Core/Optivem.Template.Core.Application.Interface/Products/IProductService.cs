using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public interface IProductService : IApplicationService
    {
        Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request);

        Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);

        Task<FindProductResponse> FindProductAsync(FindProductRequest request);

        Task<ListProductsResponse> ListProductsAsync(ListProductsRequest request);

        Task<ListProductsResponse> ListProductsAsync();

        Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request);

        Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request);

        Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request);
    }
}
