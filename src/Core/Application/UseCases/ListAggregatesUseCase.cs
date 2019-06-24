using Optivem.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    // TODO: VC: Make optimized version for retriving all

    public class ListAggregatesUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IFindAllAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(TUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var repository = GetRepository();
            var aggregateRoots = await repository.GetAsync();

            return ResponseMapper.Map<IEnumerable<TAggregateRoot>, TResponse>(aggregateRoots);
        }
    }
    public abstract class ListAggregatesUseCase<TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        : ListAggregatesUseCase<IUnitOfWork, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IFindAllAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork, responseMapper)
        {
        }
    }
}