using System;
using System.Threading.Tasks;

namespace Optivem.Platform.Core.Common.RestClient
{
    public interface IRestControllerClient<TId> : IDisposable
    {
        Task<TResponse> GetResourcesAsync<TResponse>();

        Task<TResponse> GetResourceAsync<TResponse>(TId id);
    }
}
