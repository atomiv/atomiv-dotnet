using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    // TODO: VC: Make optimized version for retriving all

    public class ListAggregatesUseCase<TUnitOfWork, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId> 
        : BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse>
        where TUnitOfWork : ITransactionalUnitOfWork
        where TRepository : IFindAllAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(ITransactionalUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, TRepository> repositoryGetter, IResponseMapper responseMapper)
            : base(unitOfWorkFactory, repositoryGetter)
        {
            ResponseMapper = responseMapper;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            IEnumerable<TAggregateRoot> aggregateRoots;

            using(var unitOfWork = CreateUnitOfWork())
            {
                var repository = GetRepository(unitOfWork);
                aggregateRoots = await repository.GetAsync();
            }

            var records = ResponseMapper.MapEnumerable<TAggregateRoot, TRecordResponse>(aggregateRoots).ToList();

            return new TResponse
            {
                Data = records,
            };
        }
    }
}