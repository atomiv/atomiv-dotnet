using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    // TODO: VC: Base class with UpdateAggregate, ro try to do composition

    public abstract class ExecuteAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAggregateRootRepository<TAggregateRoot, TIdentity>, IExistsAggregateRootRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRootRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TResponse, TId>
        where TResponse : class, IResponse
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

            var aggregateRoot = await repository.FindAsync(identity);

            if (aggregateRoot == null)
            {
                throw new NotFoundRequestException();
            }

            try
            {
                Execute(request, aggregateRoot);
            }
            catch(DomainException ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

            try
            {
                await repository.UpdateAsync(aggregateRoot);
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
