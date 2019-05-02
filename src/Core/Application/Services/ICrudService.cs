using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services
{
    public interface ICrudService<TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TKey> : IService
    {
        Task<IEnumerable<TFindAllResponse>> FindAllAsync();

        Task<TFindResponse> FindAsync(TKey id);

        Task<TCreateResponse> CreateAsync(TCreateRequest request);

        Task<bool> UpdateAsync(TUpdateRequest request);

        Task<bool> DeleteAsync(TKey id);
    }
}
