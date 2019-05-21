using Optivem.Common.Http;
using Optivem.Common.Serialization;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;

namespace Optivem.Test.Xunit.AspNetCore
{
    public abstract class BaseTestJsonClient<TStartup> : BaseTestClient<TStartup> where TStartup : class
    {
        protected override IControllerClientFactory CreateControllerClientFactory()
        {
            var serializationService = CreateSerializationService();
            return new JsonControllerClientFactory(Client, serializationService);
        }

        protected virtual IJsonSerializationService CreateSerializationService()
        {
            return new JsonSerializationService();
        }
    }
}