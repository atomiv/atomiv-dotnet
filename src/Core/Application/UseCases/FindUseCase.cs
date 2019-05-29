using Optivem.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class FindUseCase<TRequest, TResponse, TAggregateRoot, TIdentity, TId> : IFindUseCase<TRequest, TResponse>
        where TRequest : IFindRequest<TId>
        where TResponse : IFindResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public FindUseCase(IResponseMapper responseMapper, IReadonlyCrudRepository<TAggregateRoot, TIdentity> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyCrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var identity = GetIdentity(id);
            var aggregateRoot = await Repository.GetSingleOrDefaultAsync(identity);
            var response = ResponseMapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;

            throw new NotImplementedException();
        }

        protected abstract TIdentity GetIdentity(TId id);
    }
}