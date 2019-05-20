using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.AspNetCore
{
    public abstract class BaseTestValidatedJsonClient<TStartup> : BaseTestJsonClient<TStartup> where TStartup : class
    {
        protected override IControllerClientFactory CreateControllerClientFactory()
        {
            var serializationService = CreateSerializationService();
            return new ValidatedJsonControllerClientFactory(Client, serializationService);
        }
    }
}
