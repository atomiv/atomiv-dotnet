using System;
using System.Collections.Generic;
using System.Text;
using Optivem.Common.Http;
using Optivem.Common.Serialization;

namespace Optivem.Infrastructure.Http.System
{
    public class JsonClient : ObjectClient
    {
        private const string MediaType = "application/json";

        public JsonClient(IClient client, IJsonSerializationService serializationService) 
            : base(client, serializationService, MediaType, MediaType)
        {
        }
    }
}
