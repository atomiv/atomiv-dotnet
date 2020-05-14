using Optivem.Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class BaseUser : IUser
    {
        public BaseUser(ClaimsPrincipal principal)
        {
            Principal = principal;
        }

        protected ClaimsPrincipal Principal { get; }

        public IIdentity Identity => Principal.Identity;

        public bool HasActionPermission(string action)
        {
            return Any(ExtendedClaimTypes.ActionType, action);
        }

        public bool IsInRole(string role)
        {
            return Principal.IsInRole(role);
        }

        protected string GetFirstOrDefault(string claimType)
        {
            var claim = Principal.Claims
                .FirstOrDefault(e => e.Type == claimType);

            return claim?.Value;
        }

        protected string GetFirst(string claimType)
        {
            var claim = Principal.Claims
                .First(e => e.Type == claimType);

            return claim.Value;
        }

        protected string GetSingleOrDefault(string claimType)
        {
            var claim = Principal.Claims
                .SingleOrDefault(e => e.Type == claimType);

            return claim?.Value;
        }

        protected string GetSingle(string claimType)
        {
            var claim = Principal.Claims
                .Single(e => e.Type == claimType);

            return claim.Value;
        }

        protected IEnumerable<string> GetAll(string claimType)
        {
            return Principal.Claims
                .Where(e => e.Type == claimType)
                .Select(e => e.Value)
                .ToList();
        }

        protected bool Any(string claimType)
        {
            return Principal.Claims
                .Any(e => e.Type == claimType);
        }

        protected bool Any(string claimType, string claimValue)
        {
            return Principal.Claims
                .Any(e => e.Type == claimType
                    && e.Value == claimValue);
        }
    }
}