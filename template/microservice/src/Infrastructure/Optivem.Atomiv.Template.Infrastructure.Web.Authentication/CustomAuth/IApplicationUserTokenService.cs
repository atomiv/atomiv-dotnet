using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Context;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.CustomAuth
{
    public interface IApplicationUserTokenService : IApplicationService
    {
        Task<ApplicationUser> GetApplicationUserAsync(string token);
    }
}
