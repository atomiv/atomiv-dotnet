using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class DeleteAggregateCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IExistAggregateRepository<TAggregateRoot, TIdentity>, IRemoveAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : IResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteAggregateCase(TUnitOfWork unitOfWork, IIdentityFactory<TIdentity, TId> identityFactory)
            : base(unitOfWork)
        {
            IdentityFactory = identityFactory;
        }

        protected IIdentityFactory<TIdentity, TId> IdentityFactory { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = IdentityFactory.Create(id);

            var repository = GetRepository();
            var exists = await repository.GetExistsAsync(identity);

            if (!exists)
            {
                throw new RequestNotFoundException();
            }

            // TODO: VC: Should delete check if exists?

            repository.Delete(identity);

            await UnitOfWork.SaveChangesAsync();

            return new TResponse();
        }
    }
    public abstract class DeleteAggregateCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : DeleteAggregateCase<IUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IExistAggregateRepository<TAggregateRoot, TIdentity>, IRemoveAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : IResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteAggregateCase(IUnitOfWork unitOfWork, IIdentityFactory<TIdentity, TId> identityFactory) 
            : base(unitOfWork, identityFactory)
        {
        }
    }
}