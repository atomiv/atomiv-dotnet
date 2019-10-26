using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class Repository<TAggregateRoot, TIdentity> : IRepository
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public Repository(IRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        protected IRequestHandler RequestHandler { get; private set; }

        protected Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            return RequestHandler.HandleAsync<TRequest, TResponse>(request);
        }

        protected async Task<TAggregateRoot> HandleAddAggregateRootAsync(TAggregateRoot aggregateRoot)
        {
            var request = new AddAggregateRootRequest<TAggregateRoot, TIdentity>(aggregateRoot);
            var response = await HandleAsync<AddAggregateRootRequest<TAggregateRoot, TIdentity>, AddAggregateRootResponse<TAggregateRoot>>(request);
            return response.AggregateRoot;
        }

        protected async Task<bool> HandleExistsAggregateRootAsync(TIdentity identity)
        {
            var request = new ExistsAggregateRootRequest<TAggregateRoot, TIdentity>(identity);
            var response = await HandleAsync<ExistsAggregateRootRequest<TAggregateRoot, TIdentity>, ExistsAggregateRootResponse>(request);
            return response.Exists;
        }

        protected async Task<TAggregateRoot> HandleFindAggregateRootAsync(TIdentity identity)
        {
            var request = new FindAggregateRootRequest<TAggregateRoot, TIdentity>(identity);
            var response = await HandleAsync<FindAggregateRootRequest<TAggregateRoot, TIdentity>, FindAggregateRootResponse<TAggregateRoot>>(request);
            return response.AggregateRoot;
        }

        protected async Task<IEnumerable<TAggregateRoot>> HandleListAggregateRootsAsync()
        {
            var request = new ListAggregateRootsRequest<TAggregateRoot, TIdentity>();
            var response = await HandleAsync<ListAggregateRootsRequest<TAggregateRoot, TIdentity>, ListAggregateRootsResponse<TAggregateRoot>>(request);
            return response.AggregateRoots;
        }

        protected Task<PageAggregateRootsResponse<TAggregateRoot>> HandlePageAggregateRootsAsync(int page, int size)
        {
            var request = new PageAggregateRootsRequest<TAggregateRoot, TIdentity>(page, size);
            return HandleAsync<PageAggregateRootsRequest<TAggregateRoot, TIdentity>, PageAggregateRootsResponse<TAggregateRoot>>(request);
        }

        protected Task HandleRemoveAggregateRootAsync(TIdentity identity)
        {
            var request = new RemoveAggregateRootRequest<TAggregateRoot, TIdentity>(identity);
            return HandleAsync<RemoveAggregateRootRequest<TAggregateRoot, TIdentity>, RemoveAggregateRootResponse>(request);
        }

        protected async Task<TAggregateRoot> HandleUpdateAggregateRootAsync(TAggregateRoot aggregateRoot)
        {
            var request = new UpdateAggregateRootRequest<TAggregateRoot, TIdentity>(aggregateRoot);
            var response = await HandleAsync<UpdateAggregateRootRequest<TAggregateRoot, TIdentity>, UpdateAggregateRootResponse<TAggregateRoot>>(request);
            return response.AggregateRoot;
        }
    }
}