using Optivem.Framework.Core.Common.Http;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class BaseHttpService<TService> : IHttpService where TService : IHttpService
    {
        public BaseHttpService(TService service)
        {
            Service = service;
        }

        public TService Service { get; }

        protected async Task<TResponse> ExecuteAsync<TResponse>(Func<TService, Task<IObjectClientResponse<TResponse>>> action)
        {
            var response = await action(Service);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.Data;
        }
    }
}