using Optivem.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class FindAggregateUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : ITransactionalUnitOfWork
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public FindAggregateUseCase(ITransactionalUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, 
            Func<TUnitOfWork, TRepository> repositoryGetter, 
            IResponseMapper responseMapper)
            : base(unitOfWorkFactory, repositoryGetter)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = GetIdentity(id);

            TAggregateRoot aggregateRoot;

            using(var unitOfWork = CreateUnitOfWork())
            {
                var repository = GetRepository(unitOfWork);
                aggregateRoot = await repository.GetSingleOrDefaultAsync(identity);
            }

            if(aggregateRoot == null)
            {
                throw new RequestNotFoundException();
            }

            var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }

        protected abstract TIdentity GetIdentity(TId id);
    }
}