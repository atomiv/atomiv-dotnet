using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IContentControllerClientFactory
    {
        IContentControllerClient Create(string controllerUri);
    }
}
