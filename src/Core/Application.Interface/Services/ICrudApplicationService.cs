using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public interface ICrudApplicationService<TId,
        TFindAllRequest, TCreateRequest, TUpdateRequest,
        TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        : IApplicationService
    {
        Task<TFindAllResponse> FindAllAsync(TFindAllRequest request);

        Task<TFindResponse> FindAsync(TId id);

        Task<TCreateResponse> CreateAsync(TCreateRequest request);

        Task<TUpdateResponse> UpdateAsync(TUpdateRequest request);

        Task DeleteAsync(TId id);
    }
}