using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Template.Core.Application.Context
{
    public interface IApplicationUserContext : IApplicationUserContext<ApplicationUser, RequestType>
    {
    }
}
