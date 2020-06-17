using Microsoft.AspNetCore.Http;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Core.Application.Context;
using Optivem.Atomiv.Template.Core.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.Common
{
    public class ApplicationUserContext : ApplicationUserContext<ApplicationUser, RequestType>, IApplicationUserContext
    {
        public ApplicationUserContext(IHttpContextAccessor httpContextAccessor, IApplicationUserSerializer<ApplicationUser, RequestType> userFactory) : base(httpContextAccessor, userFactory)
        {
        }
    }
}
