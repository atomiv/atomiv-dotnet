using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class CreateAggregateUseCase<TUnitOfWork, TResponseMapper, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TResponseMapper : IResponseMapper<TAggregateRoot, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(TUnitOfWork unitOfWork, TResponseMapper responseMapper)
            : base(unitOfWork)
        {
            ResponseMapper = responseMapper;
        }

        protected TResponseMapper ResponseMapper { get; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = CreateAggregateRoot(request);

            var repository = GetRepository();
            var identity = await repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();

            aggregateRoot = CreateAggregateRoot(aggregateRoot, identity);

            var response = ResponseMapper.Map(aggregateRoot);
            return response;
        }

        protected abstract TAggregateRoot CreateAggregateRoot(TRequest request);

        protected abstract TAggregateRoot CreateAggregateRoot(TAggregateRoot aggregateRoot, TIdentity identity);
    }

    public abstract class CreateAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : CreateAggregateUseCase<IUnitOfWork, IResponseMapper<TAggregateRoot, TResponse>, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(IUnitOfWork unitOfWork, IResponseMapper<TAggregateRoot, TResponse> responseMapper) 
            : base(unitOfWork, responseMapper)
        {
        }
    }
}