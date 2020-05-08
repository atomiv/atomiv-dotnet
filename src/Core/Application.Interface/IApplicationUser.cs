using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Optivem.Atomiv.Core.Application
{
    public interface IApplicationUser : IPrincipal
    {
        bool HasActionPermission(string action);
    }
}
