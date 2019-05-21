using Microsoft.AspNetCore.Mvc;
using Optivem.Core.Application;

namespace Optivem.Web.AspNetCore
{
    public class BaseController<TService> : ControllerBase 
        where TService : IService
    {
        public BaseController(TService service)
        {
            Service = service;
        }

        protected TService Service { get; private set; }
    }
}
