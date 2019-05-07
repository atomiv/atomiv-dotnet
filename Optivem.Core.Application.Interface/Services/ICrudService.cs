using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Application.Services
{
    public interface ICrudService<TId, 
        TFindAllRequest, TCreateRequest, TUpdateRequest, 
        TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse> 
        : IService
    {
        Task<TFindAllResponse> FindAllAsync(TFindAllRequest request);

        Task<TFindResponse> FindAsync(TId id);

        Task<TCreateResponse> CreateAsync(TCreateRequest request);

        Task<TUpdateResponse> UpdateAsync(TUpdateRequest request);

        Task<bool> DeleteAsync(TId id);
    }
}
