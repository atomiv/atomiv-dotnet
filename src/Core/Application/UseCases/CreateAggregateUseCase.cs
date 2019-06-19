using Optivem.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class CreateAggregateUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(TUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = CreateAggregateRoot(request);

            var repository = GetRepository();
            var identity = await repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();

            aggregateRoot = CreateAggregateRoot(aggregateRoot, identity);

            var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }

        protected abstract TAggregateRoot CreateAggregateRoot(TRequest request);

        protected abstract TAggregateRoot CreateAggregateRoot(TAggregateRoot aggregateRoot, TIdentity identity);
    }

    public abstract class CreateAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : CreateAggregateUseCase<IUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) 
            : base(unitOfWork, responseMapper)
        {
        }
    }
}