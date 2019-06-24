using Optivem.Core.Application.UseCases.Base;
using Optivem.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    // TODO: VC: Make optimized version for retriving all

    // TODO: Move response mapper to base

    public class ListAggregatesUseCase<TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId> 
        : RepositoryUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAllAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(TRepository repository, IResponseMapper responseMapper)
            : base(repository)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var aggregateRoots = await Repository.GetAsync();

            return ResponseMapper.Map<IEnumerable<TAggregateRoot>, TResponse>(aggregateRoots);
        }
    }

    // TODO: VC: DELETE

    /*
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
    */
}