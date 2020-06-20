using Atomiv.Core.Common.Http;
using Atomiv.Infrastructure.AspNetCore;
using Cli.Web.RestClient.Interface;

namespace Cli.Web.RestClient.Http
{
    public class ApiHttpService : BaseApiClient, IApiHttpService
    {
        public ApiHttpService(IControllerClientFactory clientFactory)
            : base(clientFactory)
        {
            MyFoos = new MyFooHttpService(clientFactory);
        }

        public IMyFooHttpService MyFoos { get; }
    }
}
