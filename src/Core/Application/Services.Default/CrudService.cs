using MediatR;
using Optivem.Framework.Core.Application.UseCases;
using Optivem.Framework.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services.Default
{
    public class CrudService<TKey, TFindAllCommand, TFindCommand, TCreateCommand, TUpdateCommand, TDeleteCommand, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse, TEntity> 
        : ICrudService<TKey, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TFindAllCommand : ICommand<object, IEnumerable<TFindAllResponse>>, new()
        where TFindCommand : ICommand<TKey, TFindResponse>, new()
        where TCreateCommand : ICommand<TCreateRequest, TCreateResponse>, new()
        where TUpdateCommand : ICommand<TUpdateRequest, TUpdateResponse>, new()
        where TDeleteCommand : ICommand<TKey, bool>, new()
        where TEntity : class, IEntity<TKey>
    {
        public CrudService(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; private set; }

        public Task<IEnumerable<TFindAllResponse>> FindAllAsync()
        {
            return SendCommand<TFindAllCommand, object, IEnumerable<TFindAllResponse>>(null);
        }

        public Task<TFindResponse> FindAsync(TKey id)
        {
            return SendCommand<TFindCommand, TKey, TFindResponse>(id);
        }

        public Task<TCreateResponse> CreateAsync(TCreateRequest request)
        {
            return SendCommand<TCreateCommand, TCreateRequest, TCreateResponse>(request);
        }

        public Task<TUpdateResponse> UpdateAsync(TUpdateRequest request)
        {
            return SendCommand<TUpdateCommand, TUpdateRequest, TUpdateResponse>(request);
        }

        public Task<bool> DeleteAsync(TKey id)
        {
            return SendCommand<TDeleteCommand, TKey, bool>(id);
        }

        protected Task<TResponse> SendCommand<TCommand, TRequest, TResponse>(TRequest request) where TCommand : ICommand<TRequest, TResponse>, new()
        {
            var command = new TCommand
            {
                Request = request,
            };

            return Mediator.Send(command);
        }
    }
}
