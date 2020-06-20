using Atomiv.Core.Common.Http;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using System.Threading.Tasks;

namespace Cli.Web.RestClient.Interface
{
    public interface IMyFooHttpService : IHttpService
    {
        Task<IObjectClientResponse<CreateMyFooResponse>> CreateMyFooAsync(CreateMyFooRequest request);

        Task<IObjectClientResponse<DeleteMyFooResponse>> DeleteMyFooAsync(DeleteMyFooRequest request);

        Task<IObjectClientResponse<FindMyFooResponse>> FindMyFooAsync(FindMyFooRequest request);

        Task<IObjectClientResponse<ListMyFoosResponse>> ListMyFoosAsync(ListMyFoosRequest request);

        Task<IObjectClientResponse<UpdateMyFooResponse>> UpdateMyFooAsync(UpdateMyFooRequest request);
    }
}
