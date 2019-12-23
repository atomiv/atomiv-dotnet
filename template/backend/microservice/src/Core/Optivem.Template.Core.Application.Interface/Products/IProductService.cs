using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public interface IProductService : IApplicationService
    {
        Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request);

        Task<ProductResponse> CreateProductAsync(CreateProductRequest request);

        Task<FindProductResponse> FindProductAsync(FindProductRequest request);

        Task<ListProductsResponse> ListProductsAsync(ListProductRequest request);

        Task<ProductResponse> RelistProductAsync(RelistProductRequest request);

        Task<ProductResponse> UnlistProductAsync(UnlistProductRequest request);

        Task<ProductResponse> UpdateProductAsync(UpdateProductRequest request);
    }
}