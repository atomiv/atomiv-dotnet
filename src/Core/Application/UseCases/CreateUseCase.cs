using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class CreateUseCase<TRequest, TResponse, TEntity, TId> : ICreateUseCase<TRequest, TResponse>
        where TRequest : ICreateRequest
        where TResponse : ICreateResponse<TId>
        where TEntity : class, IEntity<TId>
    {
        public CreateUseCase(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<TEntity, TId> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper RequestMapper { get; private set; }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var entity = RequestMapper.Map<TRequest, TEntity>(request);
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            var response = ResponseMapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }
}