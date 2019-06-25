using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    // TODO: VC: Inherit from base service with all the methods filled up

    public class CrudService<TId,
        TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest,
        TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse, TDeleteResponse>
        : ICrudApplicationService<TId, TFindAllRequest, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TFindAllRequest : IRequest
        where TFindRequest : IRequest<TId>, new()
        where TCreateRequest : IRequest
        where TUpdateRequest : IRequest
        where TDeleteRequest : IRequest<TId>, new()
        where TFindAllResponse : IResponse
        where TFindResponse : IResponse
        where TCreateResponse : IResponse
        where TUpdateResponse : IResponse
        where TDeleteResponse : IResponse
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

        public Task DeleteAsync(TId id)
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            return _requestHandler.HandleAsync<TDeleteRequest, TDeleteResponse>(request);
        }
    }
}