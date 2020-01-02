using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public interface IProductApplicationService : IApplicationService
    {
        Task<BrowseProductsQueryResponse> BrowseProductsAsync(BrowseProductsQuery request);

        Task<CreateProductCommandResponse> CreateProductAsync(CreateProductCommand request);

        Task<FindProductQueryResponse> FindProductAsync(FindProductQuery request);

        Task<ListProductsQueryResponse> ListProductsAsync(ListProductQuery request);

        Task<RelistProductCommandResponse> RelistProductAsync(RelistProductCommand request);

        Task<UnlistProductCommandResponse> UnlistProductAsync(UnlistProductCommand request);

        Task<UpdateProductCommandResponse> UpdateProductAsync(UpdateProductCommand request);
    }
}