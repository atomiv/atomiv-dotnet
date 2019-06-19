using Optivem.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class CreateAggregateUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : ITransactionalUnitOfWork
        where TRepository : IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(ITransactionalUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, TRepository> repositoryGetter, IResponseMapper responseMapper)
            : base(unitOfWorkFactory, repositoryGetter)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = CreateAggregateRoot(request);

            TIdentity identity;

            using (var unitOfWork = CreateUnitOfWork())
            {
                var repository = GetRepository(unitOfWork);
                identity = await repository.AddAsync(aggregateRoot);
                await unitOfWork.SaveChangesAsync();
            }

            aggregateRoot = CreateAggregateRoot(aggregateRoot, identity);

            var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }

        protected abstract TAggregateRoot CreateAggregateRoot(TRequest request);

        protected abstract TAggregateRoot CreateAggregateRoot(TAggregateRoot aggregateRoot, TIdentity identity);
    }
}