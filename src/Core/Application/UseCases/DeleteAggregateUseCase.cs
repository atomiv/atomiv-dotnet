using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class DeleteAggregateCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest<TId>
        where TResponse : IResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteAggregateCase(IIdentityFactory<TIdentity, TId> identityFactory, 
            IUnitOfWork unitOfWork, 
            ICrudRepository<TAggregateRoot, TIdentity> repository)
        {
            IdentityFactory = identityFactory;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IIdentityFactory<TIdentity, TId> IdentityFactory { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = IdentityFactory.Create(id);

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
    }
}