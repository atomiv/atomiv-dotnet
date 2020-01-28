using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Application.MyFoos.Services;
using Optivem.Cli.Web.RestClient.Interface;
using System.Threading.Tasks;

namespace Optivem.Cli.Web.RestClient
{
    public class MyFooService : BaseHttpService<IMyFooHttpService>, IMyFooService
    {
        public MyFooService(IMyFooHttpService service)
            : base(service)
        {
        }

        public Task<CreateMyFooResponse> CreateMyFooAsync(CreateMyFooRequest request)
        {
            return ExecuteAsync(e => e.CreateMyFooAsync(request));
        }

        public Task<DeleteMyFooResponse> DeleteMyFooAsync(DeleteMyFooRequest request)
        {
            return ExecuteAsync(e => e.DeleteMyFooAsync(request));
        }

        public Task<FindMyFooResponse> FindMyFooAsync(FindMyFooRequest request)
        {
            return ExecuteAsync(e => e.FindMyFooAsync(request));
        }

        public Task<ListMyFoosResponse> ListMyFoosAsync(ListMyFoosRequest request)
        {
            return ExecuteAsync(e => e.ListMyFoosAsync(request));
        }

        public Task<UpdateMyFooResponse> UpdateMyFooAsync(UpdateMyFooRequest request)
        {
            return ExecuteAsync(e => e.UpdateMyFooAsync(request));
        }
    }
}
