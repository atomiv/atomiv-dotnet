using Optivem.Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication
{
    public interface ICustomAuthenticationTokenService : IApplicationService
    {
        Task<CustomAuthenticationUserInfo> GetUserInfoAsync(string token);
    }
}
