using Atomiv.Core.Application;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using System.Threading.Tasks;

namespace Cli.Core.Application.MyFoos.Services
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