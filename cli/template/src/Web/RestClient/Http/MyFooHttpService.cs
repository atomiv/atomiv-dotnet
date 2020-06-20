using Atomiv.Core.Common.Http;
using Atomiv.Infrastructure.AspNetCore;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Web.RestClient.Interface;
using System;
using System.Threading.Tasks;

namespace Cli.Web.RestClient.Http
{
    public class MyFooHttpService : BaseControllerClient, IMyFooHttpService
    {
        public MyFooHttpService(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/my-foos")
        {
        }

        public Task<IObjectClientResponse<CreateMyFooResponse>> CreateMyFooAsync(CreateMyFooRequest request)
        {
            return Client.PostAsync<CreateMyFooRequest, CreateMyFooResponse>(request);
        }

        public Task<IObjectClientResponse<DeleteMyFooResponse>> DeleteMyFooAsync(DeleteMyFooRequest request)
        {
            var id = request.Id;
            return Client.DeleteByIdAsync<int, DeleteMyFooResponse>(id);
        }

        public Task<IObjectClientResponse<FindMyFooResponse>> FindMyFooAsync(FindMyFooRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<int, FindMyFooResponse>(id);
        }

        public Task<IObjectClientResponse<ListMyFoosResponse>> ListMyFoosAsync(ListMyFoosRequest request)
        {
            return Client.GetAsync<ListMyFoosResponse>();
        }

        public Task<IObjectClientResponse<UpdateMyFooResponse>> UpdateMyFooAsync(UpdateMyFooRequest request)
        {
            return Client.PutByIdAsync<int, UpdateMyFooRequest, UpdateMyFooResponse>(request.Id, request);
        }
    }
}
