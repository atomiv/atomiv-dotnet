using Microsoft.AspNetCore.Http;
using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IUser User
        {
            get
            {
                var principal = _httpContextAccessor.HttpContext.User;
                return new User(principal);
            }
        }
    }
}
