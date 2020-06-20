using Atomiv.Core.Application;
using Atomiv.Template.Core.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Core.Application.Context
{
    public interface IApplicationUserContext : IApplicationUserContext<ApplicationUser, RequestType>
    {
    }
}
