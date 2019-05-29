using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class CreateUseCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : ICreateUseCase<TRequest, TResponse>
        where TRequest : ICreateRequest
        where TResponse : ICreateResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateUseCase(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<TAggregateRoot, TIdentity> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper RequestMapper { get; private set; }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = RequestMapper.Map<TRequest, TAggregateRoot>(request);
            var identity = await Repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();
            aggregateRoot = GetAggregateRoot(aggregateRoot, identity);
            var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }

        protected abstract TAggregateRoot GetAggregateRoot(TAggregateRoot aggregateRoot, TIdentity identity);
    }
}