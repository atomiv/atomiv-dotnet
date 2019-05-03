using Optivem.Framework.Core.Application.Dtos;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Application.UseCases.MediatR
{
    public class UpdateCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TRequest, TResponse>
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TRequest, TResponse>
        where TCommand : ICommand<TRequest, TResponse>
        where TRequest : IIdentifiable<TKey>
        where TResponse : class
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public UpdateCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(requestMapper, responseMapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var request = command.Request;
            var id = request.Id;

            var exists = await Repository.GetExistsAsync(id);

            if(!exists)
            {
                return null;
            }

            var entity = RequestMapper.Map<TRequest, TEntity>(request);

            try
            {
                Repository.Update(entity);
                await UnitOfWork.SaveChangesAsync();

                var retrieved = await Repository.GetSingleOrDefaultAsync(id);

                if(retrieved == null)
                {
                    return null;
                }

                var response = ResponseMapper.Map<TEntity, TResponse>(retrieved);
                return response;
            }
            catch (ConcurrentUpdateException)
            {
                exists = await Repository.GetExistsAsync(id);

                if (!exists)
                {
                    return null;
                }

                throw;
            }
        }
    }

    public class UpdateCommandHandler<TKey, TEntity, TCommand, TRequest, TResponse>
        : UpdateCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TCommand, TRequest, TResponse>
        where TCommand : ICommand<TRequest, TResponse>
        where TRequest : IIdentifiable<TKey>
        where TResponse : class
        where TEntity : class, IEntity<TKey>
    {
        public UpdateCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork)
            : base(requestMapper, responseMapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
