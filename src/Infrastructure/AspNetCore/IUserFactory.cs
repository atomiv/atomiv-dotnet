using Optivem.Atomiv.Core.Application;
using System.Security.Claims;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public interface IUserFactory<TUser> where TUser : IUser
    {
        TUser Create(ClaimsPrincipal principal);
    }
}
