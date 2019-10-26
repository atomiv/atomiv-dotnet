using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UpdateAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAggregateRootRepository<TAggregateRoot, TIdentity>, IExistsAggregateRootRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRootRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TResponse, TId>
        where TResponse : IResponse
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

            var aggregateRoot = await repository.FindAsync(identity);

            if (aggregateRoot == null)
            {
                throw new NotFoundRequestException();
            }

            await UpdateAsync(request, aggregateRoot);

            try
            {
                aggregateRoot = await repository.UpdateAsync(aggregateRoot);
                await UnitOfWork.SaveChangesAsync();
                var response = Mapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
                return response;
            }
            catch (ConcurrentUpdateException ex)
            {
                var exists = await repository.ExistsAsync(identity);

                if (!exists)
                {
                    throw new NotFoundRequestException(ex.Message, ex);
                }

                throw;
            }
        }

        protected abstract Task UpdateAsync(TRequest request, TAggregateRoot aggregateRoot);
    }
}