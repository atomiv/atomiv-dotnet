using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class DeleteAggregateCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IExistsAggregateRootRepository<TAggregateRoot, TIdentity>, IRemoveAggregateRootRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TResponse, TId>
        where TResponse : IResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteAggregateCase(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = Mapper.Map<TId, TIdentity>(id);

            var repository = GetRepository();
            var exists = await repository.ExistsAsync(identity);

            if (!exists)
            {
                throw new NotFoundRequestException();
            }

            await repository.RemoveAsync(identity);

            await UnitOfWork.SaveChangesAsync();

            return new TResponse();
        }
    }
}