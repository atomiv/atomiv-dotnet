using Microsoft.AspNetCore.Http;
using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class RequestContext : IRequestContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IApplicationUser User
        {
            get
            {
                var principal = _httpContextAccessor.HttpContext.User;
                return new ApplicationUser(principal);
            }
        }
    }
}
