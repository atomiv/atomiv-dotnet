using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public abstract class BaseUseCase<TUnitOfWork, TRepository, TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public BaseUseCase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public abstract Task<TResponse> HandleAsync(TRequest request);

        protected IUnitOfWork UnitOfWork { get; }

        protected TRepository GetRepository()
        {
            return UnitOfWork.GetRepository<TRepository>();
        }
    }

    public abstract class BaseUseCase<TRepository, TRequest, TResponse> 
        : BaseUseCase<IUnitOfWork, TRepository, TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public BaseUseCase(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }
    }

}
