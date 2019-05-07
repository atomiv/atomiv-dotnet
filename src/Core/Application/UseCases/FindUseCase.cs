using Optivem.Core.Application.Mappers;
using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using Optivem.Core.Domain.Entities;
using Optivem.Core.Domain.Repositories;
using System.Threading.Tasks;

namespace Optivem.Core.Application.UseCases
{
    public class FindUseCase<TRequest, TResponse, TEntity, TId> : IFindUseCase<TRequest, TResponse>
        where TRequest : IFindRequest<TId>
        where TResponse : IFindResponse<TId>
        where TEntity : class, IEntity<TId>
    {
        public FindUseCase(IResponseMapper responseMapper, IReadonlyRepository<TEntity, TId> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var entity = await Repository.GetSingleOrDefaultAsync(id);
            var response = ResponseMapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }
}
