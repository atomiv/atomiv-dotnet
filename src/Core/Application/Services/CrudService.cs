using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class CrudService<TId,  
        TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, 
        TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse, TDeleteResponse> 
        : ICrudService<TId, TFindAllRequest, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TFindAllRequest : IFindAllRequest
        where TFindRequest : IFindRequest<TId>, new()
        where TCreateRequest : ICreateRequest
        where TUpdateRequest : IUpdateRequest
        where TDeleteRequest : IDeleteRequest<TId>, new()
        where TFindAllResponse : IFindAllResponse
        where TFindResponse : IFindResponse
        where TCreateResponse : ICreateResponse
        where TUpdateResponse : IUpdateResponse
        where TDeleteResponse : IDeleteResponse
    {
        private IUseCaseMediator _mediator;

        public CrudService(IUseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TFindAllResponse> FindAllAsync(TFindAllRequest request)
        {
            return _mediator.HandleAsync<TFindAllRequest, TFindAllResponse>(request);
        }

        public Task<TFindResponse> FindAsync(TId id)
        {
            var request = new TFindRequest
            {
                Id = id,
            };

            return _mediator.HandleAsync<TFindRequest, TFindResponse>(request);
        }

        public Task<TCreateResponse> CreateAsync(TCreateRequest request)
        {
            return _mediator.HandleAsync<TCreateRequest, TCreateResponse>(request);
        }

        public Task<TUpdateResponse> UpdateAsync(TUpdateRequest request)
        {
            return _mediator.HandleAsync<TUpdateRequest, TUpdateResponse>(request);
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            var response = await _mediator.HandleAsync<TDeleteRequest, TDeleteResponse>(request);

            return response.Deleted;
        }
    }
}
