using Optivem.Atomiv.Core.Common.Http;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using System.Threading.Tasks;

namespace Optivem.Cli.Web.RestClient.Interface
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
