using Optivem.Atomiv.Infrastructure.AspNetCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.Common
{
    public class UserFactory : IUserFactory<User>
    {
        public User Create(ClaimsPrincipal principal)
        {
            return new User(principal);
        }
    }
}
