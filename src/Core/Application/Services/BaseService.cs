using System.Threading.Tasks;

namespace Optivem.Core.Application.Services
{
    public class BaseService : IService
    {
        public BaseService(IRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        protected IRequestHandler RequestHandler { get; private set; }

        protected Task<TListResponse> ListAsync<TListRequest, TListResponse>()
            where TListRequest : IListRequest, new()
            where TListResponse : IListResponse
        {
            var request = new TListRequest();
            return RequestHandler.HandleAsync<TListRequest, TListResponse>(request);
        }

        protected Task<TCreateResponse> CreateAsync<TCreateRequest, TCreateResponse>(TCreateRequest request)
            where TCreateRequest : ICreateRequest, new()
            where TCreateResponse : ICreateResponse
        {
            return RequestHandler.HandleAsync<TCreateRequest, TCreateResponse>(request);
        }

        protected Task<TUpdateResponse> UpdateAsync<TUpdateRequest, TUpdateResponse>(TUpdateRequest request)
            where TUpdateRequest : IUpdateRequest, new()
            where TUpdateResponse : IUpdateResponse
        {
            return RequestHandler.HandleAsync<TUpdateRequest, TUpdateResponse>(request);
        }

        protected Task<TFindResponse> FindAsync<TId, TFindRequest, TFindResponse>(TId id)
            where TFindRequest : IFindRequest<TId>, new()
            where TFindResponse : IFindResponse<TId>
        {
            var request = new TFindRequest
            {
                Id = id,
            };

            return RequestHandler.HandleAsync<TFindRequest, TFindResponse>(request);
        }
        protected Task<TDeleteResponse> DeleteAsync<TId, TDeleteRequest, TDeleteResponse>(TId id)
            where TDeleteRequest : IDeleteRequest<TId>, new()
            where TDeleteResponse : IDeleteResponse
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            return RequestHandler.HandleAsync<TDeleteRequest, TDeleteResponse>(request);
        }
    }
}