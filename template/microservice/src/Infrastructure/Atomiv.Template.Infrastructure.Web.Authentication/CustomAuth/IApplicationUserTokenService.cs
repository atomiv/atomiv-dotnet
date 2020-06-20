using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Context;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Web.Authentication.CustomAuth
{
    public interface IApplicationUserTokenService : IApplicationService
    {
        Task<ApplicationUser> GetApplicationUserAsync(string token);
    }
}
