using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UpdateAggregateUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>, IExistAggregateRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public UpdateAggregateUseCase(TUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = GetIdentity(id);

            var repository = GetRepository();

            var aggregateRoot = await repository.GetSingleOrDefaultAsync(identity);

            if (aggregateRoot == null)
            {
                throw new NotFoundRequestException();
            }

            Update(aggregateRoot, request);

            try
            {
                repository.Update(aggregateRoot);
                await UnitOfWork.SaveChangesAsync();
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

        protected abstract TIdentity GetIdentity(TId id);

        protected abstract void Update(TAggregateRoot aggregateRoot, TRequest request);
    }
    public abstract class UpdateAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UpdateAggregateUseCase<IUnitOfWork, TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>, IExistAggregateRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public UpdateAggregateUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) 
            : base(unitOfWork, responseMapper)
        {
        }
    }
}