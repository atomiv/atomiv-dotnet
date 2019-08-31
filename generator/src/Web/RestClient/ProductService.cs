using System.Threading.Tasks;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Application.Products.Services;
using Optivem.Generator.Web.RestClient.Interface;

namespace Optivem.Generator.Web.RestClient
{
    public class ProductService : BaseHttpService<IProductHttpService>, IProductService
    {
        public ProductService(IProductHttpService service) : base(service)
        {
        }

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return ExecuteAsync(e => e.BrowseProductsAsync(request));
        }

        public Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            return ExecuteAsync(e => e.CreateProductAsync(request));
        }

        public Task<FindProductResponse> FindProductAsync(FindProductRequest request)
        {
            return ExecuteAsync(e => e.FindProductAsync(request));
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductsRequest request)
        {
            return ExecuteAsync(e => e.ListProductsAsync(request));
        }

        public Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request)
        {
            return ExecuteAsync(e => e.RelistProductAsync(request));
        }

        public Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request)
        {
            return ExecuteAsync(e => e.UnlistProductAsync(request));
        }

        public Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            return ExecuteAsync(e => e.UpdateProductAsync(request));
        }
    }
}
