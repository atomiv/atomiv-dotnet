using Optivem.Atomiv.Infrastructure.AspNetCore;
using System.Security.Claims;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.Common
{
    public class UserFactory : IUserFactory<User>
    {
        public User Create(ClaimsPrincipal principal)
        {
            return new User(principal);
        }
    }
}
