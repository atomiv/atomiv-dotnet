using Optivem.Framework.Core.Common.Mapping;
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
        public CreateAggregateUseCase(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            //var aggregateRoot = CreateAggregateRoot(request);
            var aggregateRoot = Mapper.Map<TRequest, TAggregateRoot>(request);

            var repository = GetRepository();
            aggregateRoot = await repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();

            var response = Mapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }
    }
}