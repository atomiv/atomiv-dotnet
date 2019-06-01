using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    // TODO: VC: Inherit from base service with all the methods filled up

    public class CrudService<TId,
        TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest,
        TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse, TDeleteResponse>
        : ICrudService<TId, TFindAllRequest, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TFindAllRequest : IListRequest
        where TFindRequest : IFindRequest<TId>, new()
        where TCreateRequest : ICreateRequest
        where TUpdateRequest : IUpdateRequest
        where TDeleteRequest : IDeleteRequest<TId>, new()
        where TFindAllResponse : IListResponse
        where TFindResponse : IFindResponse
        where TCreateResponse : ICreateResponse
        where TUpdateResponse : IUpdateResponse
        where TDeleteResponse : IDeleteResponse
    {
        private IRequestHandler _requestHandler;

        public CrudService(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public Task<TFindAllResponse> FindAllAsync(TFindAllRequest request)
        {
            return _requestHandler.HandleAsync<TFindAllRequest, TFindAllResponse>(request);
        }

        public Task<TFindResponse> FindAsync(TId id)
        {
            var request = new TFindRequest
            {
                Id = id,
            };

            return _requestHandler.HandleAsync<TFindRequest, TFindResponse>(request);
        }

        public Task<TCreateResponse> CreateAsync(TCreateRequest request)
        {
            return _requestHandler.HandleAsync<TCreateRequest, TCreateResponse>(request);
        }

        public Task<TUpdateResponse> UpdateAsync(TUpdateRequest request)
        {
            return _requestHandler.HandleAsync<TUpdateRequest, TUpdateResponse>(request);
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            var response = await _requestHandler.HandleAsync<TDeleteRequest, TDeleteResponse>(request);

            return response.Deleted;
        }
    }
}