using Optivem.Framework.Core.Application;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using System.Threading.Tasks;

namespace Optivem.Cli.Core.Application.MyFoos.Services
{
    public interface IMyFooService : IApplicationService
    {
        Task<CreateMyFooResponse> CreateMyFooAsync(CreateMyFooRequest request);

        Task<DeleteMyFooResponse> DeleteMyFooAsync(DeleteMyFooRequest request);

        Task<FindMyFooResponse> FindMyFooAsync(FindMyFooRequest request);

        Task<ListMyFoosResponse> ListMyFoosAsync(ListMyFoosRequest request);

        Task<UpdateMyFooResponse> UpdateMyFooAsync(UpdateMyFooRequest request);
    }
}