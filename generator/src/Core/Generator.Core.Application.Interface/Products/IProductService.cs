using Atomiv.Core.Application;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using System.Threading.Tasks;

namespace Generator.Core.Application.Products
{
    public interface IProductService : IApplicationService
    {
        Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request);

        Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);

        Task<FindProductResponse> FindProductAsync(FindProductRequest request);

        Task<ListProductsResponse> ListProductsAsync(ListProductsRequest request);

        Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request);

        Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request);

        Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request);
    }
}
