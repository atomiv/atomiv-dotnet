using Microsoft.AspNetCore.Http;
using Optivem.Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public interface IUserFactory<TUser> where TUser : IUser
    {
        TUser Create(ClaimsPrincipal principal);
    }
}
