using System.Threading.Tasks;

namespace Optivem.Core.Application.Services
{
    public class BaseService : IApplicationService
    {
        public BaseService(IRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        protected IRequestHandler RequestHandler { get; private set; }

        protected Task<TListResponse> ListAsync<TListRequest, TListResponse>()
            where TListRequest : IRequest, new()
            where TListResponse : ICollectionResponse
        {
            var request = new TListRequest();
            return RequestHandler.HandleAsync<TListRequest, TListResponse>(request);
        }

        protected Task<TCreateResponse> CreateAsync<TCreateRequest, TCreateResponse>(TCreateRequest request)
            where TCreateRequest : IRequest, new()
            where TCreateResponse : IResponse
        {
            return RequestHandler.HandleAsync<TCreateRequest, TCreateResponse>(request);
        }

        protected Task<TUpdateResponse> UpdateAsync<TUpdateRequest, TUpdateResponse>(TUpdateRequest request)
            where TUpdateRequest : IRequest, new()
            where TUpdateResponse : IResponse
        {
            return RequestHandler.HandleAsync<TUpdateRequest, TUpdateResponse>(request);
        }

        protected Task<TFindResponse> FindAsync<TId, TFindRequest, TFindResponse>(TId id)
            where TFindRequest : IRequest<TId>, new()
            where TFindResponse : IResponse<TId>
        {
            var request = new TFindRequest
            {
                Id = id,
            };

            return RequestHandler.HandleAsync<TFindRequest, TFindResponse>(request);
        }
        protected Task<TDeleteResponse> DeleteAsync<TId, TDeleteRequest, TDeleteResponse>(TId id)
            where TDeleteRequest : IRequest<TId>, new()
            where TDeleteResponse : IResponse
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            return RequestHandler.HandleAsync<TDeleteRequest, TDeleteResponse>(request);
        }
    }
}