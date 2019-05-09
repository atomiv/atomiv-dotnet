using Optivem.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Infrastructure.Http.System
{
    public class RestServiceClient
    {
        public RestServiceClient(ISerializationService serializationService, HttpClient client)
        {
            SerializationService = serializationService;
            Client = client;
        }

        public ISerializationService SerializationService { get; private set; }
        public HttpClient Client { get; private set; }
    }
}
