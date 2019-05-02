using AutoMapper;
using MediatR;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public abstract class BaseHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public BaseHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Repository = repositoryRetriever(unitOfWork);
        }

        protected IMapper Mapper { get; private set; }

        protected TUnitOfWork UnitOfWork { get; private set; }

        protected TRepository Repository { get; private set; }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class BaseHandler<TKey, TEntity, TRequest, TResponse>
        : BaseHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {
        }
    }
}
