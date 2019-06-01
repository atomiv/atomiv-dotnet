using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class CreateAggregateUseCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<TAggregateRoot, TIdentity> repository)
        {
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = CreateAggregateRoot(request);
            var identity = await Repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();
            aggregateRoot = CreateAggregateRoot(aggregateRoot, identity);
            var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }

        protected abstract TAggregateRoot CreateAggregateRoot(TRequest request);

        protected abstract TAggregateRoot CreateAggregateRoot(TAggregateRoot aggregateRoot, TIdentity identity);
    }
}