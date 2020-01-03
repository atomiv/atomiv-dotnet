using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IProductHttpService : IHttpService
    {
        Task<IObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request);

        Task<IObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request);

        Task<IObjectClientResponse<FindProductQueryResponse>> FindProductAsync(FindProductQuery request);

        Task<IObjectClientResponse<ListProductsQueryResponse>> ListProductsAsync(ListProductsQuery request);

        Task<IObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request);

        Task<IObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request);

        Task<IObjectClientResponse<UpdateProductCommandResponse>> UpdateProductAsync(UpdateProductCommand request);
    }
}