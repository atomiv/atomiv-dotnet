using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class DeleteAggregateCase<TRepository, TRequest, TResponse, TAggregateRoot, TIdentity, TId>
        : UnitOfWorkUseCase<TRepository, TRequest, TResponse>
        where TRepository : IExistAggregateRepository<TAggregateRoot, TIdentity>, IRemoveAggregateRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest<TId>
        where TResponse : IResponse, new()
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public DeleteAggregateCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = Mapper.Map<TId, TIdentity>(id);

            var repository = GetRepository();
            var exists = await repository.GetExistsAsync(identity);

            if (!exists)
            {
                throw new NotFoundRequestException();
            }

            repository.Delete(identity);

            await UnitOfWork.SaveChangesAsync();

            return new TResponse();
        }
    }
}