using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public class ProductApplicationService : ApplicationService, IProductApplicationService
    {
        public ProductApplicationService(IRequestHandler requestHandler)
            : base(requestHandler)
        {
        }

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<FindProductResponse> FindProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> RelistProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> UnlistProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }

        /*

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return HandleAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<ProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            return HandleAsync<CreateProductRequest, ProductResponse>(request);
        }

        public Task<FindProductResponse> FindProductAsync(Guid id)
        {
            var request = new FindProductRequest
            {
                Id = id,
            };

            return HandleAsync<FindProductRequest, FindProductResponse>(request);
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductRequest request)
        {
            return HandleAsync<ListProductRequest, ListProductsResponse>(request);
        }

        public Task<ProductResponse> RelistProductAsync(Guid id)
        {
            var request = new RelistProductRequest
            {
                Id = id,
            };

            return HandleAsync<RelistProductRequest, ProductResponse>(request);
        }

        public Task<ProductResponse> UnlistProductAsync(Guid id)
        {
            var request = new UnlistProductRequest
            {
                Id = id,
            };

            return HandleAsync<UnlistProductRequest, ProductResponse>(request);
        }

        public Task<ProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            return HandleAsync<UpdateProductRequest, ProductResponse>(request);
        }

        */
    }
}