using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    // TODO: VC: Base class with UpdateAggregate, ro try to do composition

    public abstract class ExecuteAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAggregateRepository<TAggregateRoot, TIdentity>, IExistAggregateRepository<TAggregateRoot, TIdentity>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : class, IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ExecuteAggregateUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork)
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

            Execute(request, aggregateRoot);

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

        protected abstract void Execute(TRequest request, TAggregateRoot aggregateRoot);
    }
}
