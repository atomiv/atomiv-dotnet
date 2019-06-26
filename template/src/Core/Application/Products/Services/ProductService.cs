using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Services;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IRequestHandler requestHandler) 
            : base(requestHandler)
        {
        }

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return HandleAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<FindProductResponse> FindProductAsync(FindProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductsRequest request)
        {
            return HandleAsync<ListProductsRequest, ListProductsResponse>(request);
        }

        public Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
