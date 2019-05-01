using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services
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
