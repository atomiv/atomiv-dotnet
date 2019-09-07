using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class CreateAggregateUseCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId> 
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public CreateAggregateUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = CreateAggregateRoot(request);

            var repository = GetRepository();
            var identity = await repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();

            aggregateRoot = CreateAggregateRoot(aggregateRoot, identity);

            var response = Mapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }

        protected abstract TAggregateRoot CreateAggregateRoot(TRequest request);

        protected abstract TAggregateRoot CreateAggregateRoot(TAggregateRoot aggregateRoot, TIdentity identity);
    }
}