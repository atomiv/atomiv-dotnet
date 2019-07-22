using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Web.AspNetCore.RazorPages
{
    public class Service
    {
        public Service(IControllerClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IControllerClientFactory ClientFactory { get; set; }
    }
}
