using Optivem.Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly ClaimsPrincipal _principal;

        public ApplicationUser(ClaimsPrincipal principal)
        {

        }

        public IIdentity Identity => throw new NotImplementedException();

        public bool HasActionPermission(string action)
        {
            throw new NotImplementedException();
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
