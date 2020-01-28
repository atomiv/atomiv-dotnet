using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Services;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using System.Threading.Tasks;

namespace Optivem.Cli.Core.Application.MyFoos.Services
{
    public class MyFooService : BaseService, IMyFooService
    {
        public MyFooService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<CreateMyFooResponse> CreateMyFooAsync(CreateMyFooRequest request)
        {
            return HandleAsync<CreateMyFooRequest, CreateMyFooResponse>(request);
        }

        public Task<DeleteMyFooResponse> DeleteMyFooAsync(DeleteMyFooRequest request)
        {
            return HandleAsync<DeleteMyFooRequest, DeleteMyFooResponse>(request);
        }

        public Task<FindMyFooResponse> FindMyFooAsync(FindMyFooRequest request)
        {
            return HandleAsync<FindMyFooRequest, FindMyFooResponse>(request);
        }

        public Task<ListMyFoosResponse> ListMyFoosAsync(ListMyFoosRequest request)
        {
            return HandleAsync<ListMyFoosRequest, ListMyFoosResponse>(request);
        }

        public Task<UpdateMyFooResponse> UpdateMyFooAsync(UpdateMyFooRequest request)
        {
            return HandleAsync<UpdateMyFooRequest, UpdateMyFooResponse>(request);
        }

    }
}