using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Ports.In.Services
{
    public interface ICrudService<TKey, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse> 
        : IService
    {
        Task<IEnumerable<TFindAllResponse>> FindAllAsync();

        Task<TFindResponse> FindAsync(TKey id);

        Task<TCreateResponse> CreateAsync(TCreateRequest request);

        Task<TUpdateResponse> UpdateAsync(TUpdateRequest request);

        Task<bool> DeleteAsync(TKey id);
    }
}
