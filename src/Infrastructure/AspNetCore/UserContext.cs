using Microsoft.AspNetCore.Http;
using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class UserContext<TUser> : IUserContext<TUser> where TUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserFactory<TUser> _userFactory;

        public UserContext(IHttpContextAccessor httpContextAccessor, IUserFactory<TUser> userFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _userFactory = userFactory;
        }

        TUser IUserContext<TUser>.User => GetUser();

        IUser IUserContext.User => GetUser();

        private TUser GetUser()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            return _userFactory.Create(principal);
        }
    }
}
