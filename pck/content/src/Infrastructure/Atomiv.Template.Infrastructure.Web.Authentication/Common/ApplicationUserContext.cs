using Microsoft.AspNetCore.Http;
using Atomiv.Core.Application;
using Atomiv.Infrastructure.AspNetCore;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Infrastructure.Web.Authentication.Common
{
    public class ApplicationUserContext : ApplicationUserContext<ApplicationUser, RequestType>, IApplicationUserContext
    {
        public ApplicationUserContext(IHttpContextAccessor httpContextAccessor, IApplicationUserSerializer<ApplicationUser, RequestType> userFactory) : base(httpContextAccessor, userFactory)
        {
        }
    }
}
