using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Optivem.Atomiv.Template.Core.Application
{
    public interface IRequestContext
    {
        public IPrincipal User { get; }
    }
}
