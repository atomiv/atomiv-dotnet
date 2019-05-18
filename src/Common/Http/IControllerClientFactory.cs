using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Common.Http
{
    public interface IControllerClientFactory
    {
        IControllerClient Create(string controllerPath);
    }
}
