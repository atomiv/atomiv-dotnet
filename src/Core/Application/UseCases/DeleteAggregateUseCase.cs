using Optivem.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class DeleteAggregateCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : ITransactionalUnitOfWork
        where TRepository : IExistAggregateRepository<TAggregateRoot, TIdentity>, IRemoveAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : IResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteAggregateCase(ITransactionalUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, TRepository> repositoryGetter,
            IIdentityFactory<TIdentity, TId> identityFactory)
            : base(unitOfWorkFactory, repositoryGetter)
        {
            IdentityFactory = identityFactory;
        }

        protected IIdentityFactory<TIdentity, TId> IdentityFactory { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = IdentityFactory.Create(id);

            using(var unitOfWork = CreateUnitOfWork())
            {
                var repository = GetRepository(unitOfWork);
                var exists = await repository.GetExistsAsync(identity);

                if (!exists)
                {
                    throw new RequestNotFoundException();
                }

                // TODO: VC: Should delete check if exists?

                repository.Delete(identity);

                await unitOfWork.SaveChangesAsync();
            }

            return new TResponse();
        }
    }
}