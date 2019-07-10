using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UnitOfWorkUseCase<TUnitOfWork, TRepository, TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public UnitOfWorkUseCase(IUnitOfWork unitOfWork)
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

    public abstract class UnitOfWorkUseCase<TRepository, TRequest, TResponse> 
        : UnitOfWorkUseCase<IUnitOfWork, TRepository, TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public UnitOfWorkUseCase(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }
    }

}
