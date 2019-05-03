using AutoMapper;
using MediatR;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public abstract class BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TRequest, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public BaseCommandHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Repository = repositoryRetriever(unitOfWork);
        }

        protected IMapper Mapper { get; private set; }

        protected TUnitOfWork UnitOfWork { get; private set; }

        protected TRepository Repository { get; private set; }

        public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
    }

    public abstract class BaseCommandHandler<TKey, TEntity, TCommand, TRequest, TResponse>
        : BaseCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TCommand, TRequest, TResponse>
        where TCommand : ICommand<TRequest, TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public BaseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {
        }
    }
}
