using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Platform.Core.Application.Service
{
    public interface ICrudService<TRequest, TResponse, TKey> : IService
    {
        Task<IEnumerable<TResponse>> GetAsync();

        Task<TResponse> GetAsync(TKey id);

        TResponse Add(TRequest request);

        void Update(TRequest request);

        void Delete(TKey id);

        bool Exists(TKey id);
    }
}
