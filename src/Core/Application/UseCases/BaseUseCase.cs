using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TUnitOfWork : ITransactionalUnitOfWork
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public BaseUseCase(ITransactionalUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, TRepository> repositoryGetter)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            RepositoryGetter = repositoryGetter;
        }

        public abstract Task<TResponse> HandleAsync(TRequest request);

        protected ITransactionalUnitOfWorkFactory<TUnitOfWork> UnitOfWorkFactory { get; }

        protected Func<TUnitOfWork, TRepository> RepositoryGetter { get; }

        protected TUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.Create();
        }

        protected TRepository GetRepository(TUnitOfWork unitOfWork)
        {
            return RepositoryGetter(unitOfWork);
        }
    }
}
