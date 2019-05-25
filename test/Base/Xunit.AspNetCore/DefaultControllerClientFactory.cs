using Optivem.Common.Http;
using Optivem.Infrastructure.Http.System;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class DefaultControllerClientFactory : IControllerClientFactory
    {
        private readonly IControllerClientFactory _factory;

        public DefaultControllerClientFactory(IClient client)
        {
            Client = client;
            _factory = CreateControllerClientFactory(client);
        }

        public IClient Client { get; private set; }

        public IControllerClient Create(string controllerUri)
        {
            return _factory.Create(controllerUri);
        }

        private static IControllerClientFactory CreateControllerClientFactory(IClient client)
        {
            var serializationService = new JsonSerializationService();
            return new JsonControllerClientFactory(client, serializationService);
        }
    }
}
