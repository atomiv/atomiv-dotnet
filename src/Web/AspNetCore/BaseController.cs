using Microsoft.AspNetCore.Mvc;
using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

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
