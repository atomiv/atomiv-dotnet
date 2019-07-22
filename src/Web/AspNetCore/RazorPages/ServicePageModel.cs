using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Web.AspNetCore.RazorPages
{
    public class ServicePageModel<T> : PageModel
    {
        public ServicePageModel(T service)
        {
            Service = service;
        }

        public T Service { get; }
    }
}
