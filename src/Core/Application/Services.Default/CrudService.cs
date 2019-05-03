using Optivem.Framework.Core.Application.Ports.In.Services;
using Optivem.Framework.Core.Application.Ports.In.UseCases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services
{
    public class CrudService<TKey, TFindAllUseCase, TFindUseCase, TCreateUseCase, TUpdateUseCase, TDeleteUseCase, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse> 
        : ICrudService<TKey, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TFindAllUseCase : IFindAllUseCase<TFindAllResponse>
        where TFindUseCase : IFindUseCase<TKey, TFindResponse>
        where TCreateUseCase : ICreateUseCase<TCreateRequest, TCreateResponse>
        where TUpdateUseCase : IUpdateUseCase<TUpdateRequest, TUpdateResponse>
        where TDeleteUseCase : IDeleteUseCase<TKey>
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

        public Task<IEnumerable<TFindAllResponse>> FindAllAsync()
        {
            return FindAllUseCase.HandleAsync();
        }

        public Task<TFindResponse> FindAsync(TKey id)
        {
            return FindUseCase.HandleAsync(id);
        }

        public Task<TCreateResponse> CreateAsync(TCreateRequest request)
        {
            return CreateUseCase.HandleAsync(request);
        }

        public Task<TUpdateResponse> UpdateAsync(TUpdateRequest request)
        {
            return UpdateUseCase.HandleAsync(request);
        }

        public Task<bool> DeleteAsync(TKey id)
        {
            return DeleteUseCase.HandleAsync(id);
        }
    }
}
