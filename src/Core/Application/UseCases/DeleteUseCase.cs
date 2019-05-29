using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class DeleteUseCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : IDeleteUseCase<TRequest, TResponse>
        where TRequest : IDeleteRequest<TIdentity>
        where TResponse : IDeleteResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteUseCase(IUnitOfWork unitOfWork, ICrudRepository<TAggregateRoot, TIdentity> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var aggregateRoot = await Repository.GetSingleOrDefaultAsync(id);

            if (aggregateRoot == null)
            {
                return new TResponse
                {
                    Deleted = false,
                };
            }

            var identity = aggregateRoot.Id;

            Repository.Delete(identity);

            await UnitOfWork.SaveChangesAsync();

            return new TResponse
            {
                Deleted = false,
            };
        }

        protected abstract TIdentity GetIdentity(TId id);
    }
}