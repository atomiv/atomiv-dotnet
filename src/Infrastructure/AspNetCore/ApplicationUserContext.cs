using Microsoft.AspNetCore.Http;
using Atomiv.Core.Application;
using System;

namespace Atomiv.Infrastructure.AspNetCore
{
    public class ApplicationUserContext<TApplicationUser, TRequestType> : IApplicationUserContext<TApplicationUser, TRequestType> 
        where TApplicationUser : IApplicationUser<TRequestType>
        where TRequestType : Enum
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationUserSerializer<TApplicationUser, TRequestType> _userFactory;

        public ApplicationUserContext(IHttpContextAccessor httpContextAccessor, IApplicationUserSerializer<TApplicationUser, TRequestType> userFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _userFactory = userFactory;
        }

        public TApplicationUser ApplicationUser => GetUser();

        IApplicationUser<TRequestType> IApplicationUserContext<TRequestType>.ApplicationUser => GetUser();

        private TApplicationUser GetUser()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            var claims = principal.Claims;
            return _userFactory.Deserialize(claims);
        }
    }
}
