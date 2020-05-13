using Optivem.Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.CustomAuth
{
    public interface ICustomAuthenticationTokenService : IApplicationService
    {
        Task<CustomAuthenticationUserInfo> GetUserInfoAsync(string token);
    }
}
