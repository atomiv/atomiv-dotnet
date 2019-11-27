using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;

namespace Optivem.Framework.Web.AspNetCore
{
    public class BaseController<TService> : ControllerBase
    {
        public BaseController(TService service)
        {
            Service = service;
        }

        protected TService Service { get; private set; }
    }
}