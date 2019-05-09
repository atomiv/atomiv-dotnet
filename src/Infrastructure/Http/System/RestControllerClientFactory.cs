using Optivem.Common.Http;
using System;

namespace Optivem.Infrastructure.Http.System
{
    public class RestControllerClientFactory : IRestControllerClientFactory
    {
        public T Create<T>(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
