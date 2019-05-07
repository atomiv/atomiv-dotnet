using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using Optivem.Core.Application.Services;
using Optivem.Core.Application.UseCases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Application.Services
{
    public class CrudService<TId, TFindAllUseCase, TFindUseCase, TCreateUseCase, TUpdateUseCase, TDeleteUseCase, 
        TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, 
        TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse, TDeleteResponse> 
        : ICrudService<TId, TFindAllRequest, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TFindAllUseCase : IFindAllUseCase<TFindAllRequest, TFindAllResponse>
        where TFindUseCase : IFindUseCase<TFindRequest, TFindResponse>
        where TCreateUseCase : ICreateUseCase<TCreateRequest, TCreateResponse>
        where TUpdateUseCase : IUpdateUseCase<TUpdateRequest, TUpdateResponse>
        where TDeleteUseCase : IDeleteUseCase<TDeleteRequest, TDeleteResponse>
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
        public CrudService(TFindAllUseCase findAllUseCase, 
            TFindUseCase findUseCase, 
            TCreateUseCase createUseCase,
            TUpdateUseCase updateUseCase,
            TDeleteUseCase deleteUseCase)
        {
            FindAllUseCase = findAllUseCase;
            FindUseCase = findUseCase;
            CreateUseCase = createUseCase;
            UpdateUseCase = updateUseCase;
            DeleteUseCase = deleteUseCase;
        }

        protected TFindAllUseCase FindAllUseCase;
        protected TFindUseCase FindUseCase;
        protected TCreateUseCase CreateUseCase;
        protected TUpdateUseCase UpdateUseCase;
        protected TDeleteUseCase DeleteUseCase;

        public Task<TFindAllResponse> FindAllAsync(TFindAllRequest request)
        {
            return FindAllUseCase.HandleAsync(request);
        }

        public Task<TFindResponse> FindAsync(TId id)
        {
            var request = new TFindRequest
            {
                Id = id,
            };

            return FindUseCase.HandleAsync(request);
        }

        public Task<TCreateResponse> CreateAsync(TCreateRequest request)
        {
            return CreateUseCase.HandleAsync(request);
        }

        public Task<TUpdateResponse> UpdateAsync(TUpdateRequest request)
        {
            return UpdateUseCase.HandleAsync(request);
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            var response = await DeleteUseCase.HandleAsync(request);

            return response.Deleted;
        }
    }
}
