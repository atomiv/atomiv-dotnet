using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class DeleteUseCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest<TId>
        where TResponse : IResponse, new()
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
            var identity = GetIdentity(id);

            var aggregateRoot = await Repository.GetSingleOrDefaultAsync(identity);

            if (aggregateRoot == null)
            {
                throw new RequestNotFoundException();
            }

            // TODO: VC: Should delete check if exists?

            Repository.Delete(identity);

            await UnitOfWork.SaveChangesAsync();

            return new TResponse();
        }

        protected abstract TIdentity GetIdentity(TId id);
    }
}