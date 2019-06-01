using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class UpdateUseCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public UpdateUseCase(IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<TAggregateRoot, TIdentity> repository)
        {
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = GetIdentity(id);

            var aggregateRoot = await Repository.GetSingleOrDefaultAsync(identity);

            if(aggregateRoot == null)
            {
                throw new RequestNotFoundException();
            }

            Update(aggregateRoot, request);

            try
            {
                Repository.Update(aggregateRoot);
                await UnitOfWork.SaveChangesAsync();
                var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
                return response;
            }
            catch (ConcurrentUpdateException)
            {
                var exists = await Repository.GetExistsAsync(identity);

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
}