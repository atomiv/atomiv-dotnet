using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    // TODO: VC: Base class with UpdateAggregate, ro try to do composition

    public abstract class ExecuteAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>, IExistsAggregateRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ExecuteAggregateUseCase(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = Mapper.Map<TId, TIdentity>(id);

            var repository = GetRepository();

            var aggregateRoot = await repository.GetAsync(identity);

            if (aggregateRoot == null)
            {
                throw new NotFoundRequestException();
            }

            Execute(request, aggregateRoot);

            try
            {
                aggregateRoot = await repository.UpdateAsync(aggregateRoot);
                await UnitOfWork.SaveChangesAsync();
                var response = Mapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
                return response;
            }
            catch (ConcurrentUpdateException)
            {
                var exists = await repository.ExistsAsync(identity);

                if (!exists)
                {
                    return null;
                }

                throw;
            }
        }

        protected abstract void Execute(TRequest request, TAggregateRoot aggregateRoot);
    }
}
