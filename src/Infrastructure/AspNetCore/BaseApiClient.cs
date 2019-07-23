using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class BaseApiClient
    {
        public BaseApiClient(IControllerClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IControllerClientFactory ClientFactory { get; private set; }
    }
}
