using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services
{
    public interface ICrudService<TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse> : IService
    {
        Task<IEnumerable<TFindAllResponse>> FindAllAsync();

        Task<TFindResponse> FindAsync(TKey id);

        Task<TCreateResponse> CreateAsync(TCreateRequest request);

        Task<TUpdateResponse> UpdateAsync(TUpdateRequest request);

        Task<bool> DeleteAsync(TKey id);
    }

    public interface ICrudService<TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TCollectionResponse, TElementResponse> 
        : ICrudService<TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TCollectionResponse, TElementResponse, TElementResponse, TElementResponse>

    {
    }

    public interface ICrudService<TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TResponse>
        : ICrudService<TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TResponse, TResponse>
    {

    }
}
