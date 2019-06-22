using Optivem.Core.Common.Http;
using Optivem.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Web.Test.Clients
{
    public class ProductsControllerClient : BaseControllerClient
    {
        public ProductsControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/products")
        {
        }

        public Task<IObjectClientResponse<BrowseProductsResponse>> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return Client.GetAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<IObjectClientResponse<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            return Client.PostAsync<CreateProductRequest, CreateProductResponse>(request);
        }


        /*
        public Task<IObjectClientResponse<ListCustomersResponse>> ListCustomersAsync()
        {
            return Client.GetAsync<ListCustomersResponse>();
        }

        public Task<IObjectClientResponse<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request)
        {
            return Client.PostAsync<CreateCustomerRequest, CreateCustomerResponse>(request);
        }

        public Task<IObjectClientResponse<FindCustomerResponse>> FindCustomerAsync(int id)
        {
            return Client.GetByIdAsync<int, FindCustomerResponse>(id);
        }

        public Task<IObjectClientResponse<UpdateCustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return Client.PutByIdAsync<int, UpdateCustomerRequest, UpdateCustomerResponse>(request.Id, request);
        }

        public Task<IClientResponse> DeleteCustomerAsync(int id)
        {
            return Client.DeleteByIdAsync(id);
        }
        */
    }
}
