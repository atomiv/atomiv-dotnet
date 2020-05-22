using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Infrastructure.Web.Authentication.Common;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.CustomAuth
{
    public interface IUserInfoService : IApplicationService
    {
        Task<UserInfo> GetUserInfoAsync(string token);
    }
}
