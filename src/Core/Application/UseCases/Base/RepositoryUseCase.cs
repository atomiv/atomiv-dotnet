using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application.UseCases.Base
{
    public abstract class RepositoryUseCase<TRepository, TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public RepositoryUseCase(TRepository repository)
        {
            Repository = repository;
        }

        public abstract Task<TResponse> HandleAsync(TRequest request);

        protected TRepository Repository { get; }
    }
}
