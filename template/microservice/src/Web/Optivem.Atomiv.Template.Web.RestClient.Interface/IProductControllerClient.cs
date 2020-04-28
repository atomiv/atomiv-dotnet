using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient.Interface
{
    public interface IProductControllerClient : IHttpControllerClient
    {
        #region Commands

        Task<ObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request);

        Task<ObjectClientResponse<EditProductCommandResponse>> EditProductAsync(EditProductCommand request);

        Task<ObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request);

        Task<ObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request);

        #endregion

        #region Queries

        Task<ObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request);

        Task<ObjectClientResponse<FilterProductsQueryResponse>> FilterProductsAsync(FilterProductsQuery request);

        Task<ObjectClientResponse<ViewProductQueryResponse>> ViewProductAsync(ViewProductQuery request);

        #endregion
    }
}