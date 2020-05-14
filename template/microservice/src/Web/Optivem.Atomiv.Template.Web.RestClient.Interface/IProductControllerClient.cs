using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient.Interface
{
    public interface IProductControllerClient : IHttpControllerClient
    {
        #region Commands

        Task<ObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request, HeaderData header);

        Task<ObjectClientResponse<EditProductCommandResponse>> EditProductAsync(EditProductCommand request, HeaderData header);

        Task<ObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request, HeaderData header);

        Task<ObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request, HeaderData header);

        #endregion

        #region Queries

        Task<ObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request, HeaderData header);

        Task<ObjectClientResponse<FilterProductsQueryResponse>> FilterProductsAsync(FilterProductsQuery request, HeaderData header);

        Task<ObjectClientResponse<ViewProductQueryResponse>> ViewProductAsync(ViewProductQuery request, HeaderData header);

        #endregion
    }
}