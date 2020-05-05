using Microsoft.AspNetCore.Http;
using Optivem.Atomiv.Template.Core.Application;
using System.Security.Principal;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication
{
    public class RequestContext : IRequestContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IPrincipal User => _httpContextAccessor.HttpContext.User;
    }
}
