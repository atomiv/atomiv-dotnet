using Optivem.Atomiv.Core.Application;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class User : IUser
    {
        private readonly ClaimsPrincipal _principal;

        public User(ClaimsPrincipal principal)
        {
            _principal = principal;
        }

        public IIdentity Identity => _principal.Identity;

        public bool HasActionPermission(string action)
        {
            return _principal.Claims
                .Any(e => e.Type == ExtendedClaimTypes.ActionType
                    && e.Value == action);
        }

        public bool IsInRole(string role)
        {
            return _principal.IsInRole(role);
        }
    }
}
