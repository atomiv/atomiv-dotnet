using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UpdateAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>, IExistAggregateRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public UpdateAggregateUseCase(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = Mapper.Map<TId, TIdentity>(id);

            var repository = GetRepository();

            var aggregateRoot = await repository.GetSingleOrDefaultAsync(identity);

            if (aggregateRoot == null)
            {
                throw new NotFoundRequestException();
            }

            aggregateRoot = Mapper.Map<TRequest, TAggregateRoot>(request, aggregateRoot);

            // TODO: VC: DELETE
            // Update(aggregateRoot, request);

            try
            {
                repository.Update(aggregateRoot);
                await UnitOfWork.SaveChangesAsync();
                var response = Mapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
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

        // TODO: VC: DELETE
        // protected abstract void Update(TAggregateRoot aggregateRoot, TRequest request);
    }
}