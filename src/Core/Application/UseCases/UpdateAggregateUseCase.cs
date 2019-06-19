using Optivem.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class UpdateAggregateUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : ITransactionalUnitOfWork
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>, IExistAggregateRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public UpdateAggregateUseCase(ITransactionalUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, TRepository> repositoryGetter, IResponseMapper responseMapper)
            : base(unitOfWorkFactory, repositoryGetter)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = GetIdentity(id);

            using(var unitOfWork = CreateUnitOfWork())
            {
                var repository = GetRepository(unitOfWork);

                var aggregateRoot = await repository.GetSingleOrDefaultAsync(identity);

                if (aggregateRoot == null)
                {
                    throw new RequestNotFoundException();
                }

                Update(aggregateRoot, request);

                try
                {
                    repository.Update(aggregateRoot);
                    await unitOfWork.SaveChangesAsync();
                    var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
                    return response;
                }
                catch (ConcurrentUpdateException)
                {
                    var exists = await repository.GetExistsAsync(identity);

                    if (!exists)
                    {
                        return null;
                    }

                    throw;
                }
            }


        }

        protected abstract TIdentity GetIdentity(TId id);

        protected abstract void Update(TAggregateRoot aggregateRoot, TRequest request);
    }
}