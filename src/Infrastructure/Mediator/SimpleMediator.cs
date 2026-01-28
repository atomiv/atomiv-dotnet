using Atomiv.Core.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.Mediator
{
    public class SimpleMediator : IMessageBus, ICommandBus, IQueryBus, IEventBus
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var requestType = request.GetType();

            // Run authorization handler if registered
            var authorizationHandlerType = typeof(IRequestAuthorizationHandler<>).MakeGenericType(requestType);
            var authorizationHandler = _serviceProvider.GetService(authorizationHandlerType);
            if (authorizationHandler != null)
            {
                var authMethod = authorizationHandler.GetType().GetMethod("HandleAsync", new[] { requestType });
                if (authMethod != null)
                {
                    var authTask = (Task)authMethod.Invoke(authorizationHandler, new object[] { request });
                    await authTask;
                }
            }

            // Run validation handler if registered
            var validationHandlerType = typeof(IRequestValidationHandler<>).MakeGenericType(requestType);
            var validationHandler = _serviceProvider.GetService(validationHandlerType);
            if (validationHandler != null)
            {
                var validationMethod = validationHandler.GetType().GetMethod("HandleAsync", new[] { requestType });
                if (validationMethod != null)
                {
                    var validationTask = (Task)validationMethod.Invoke(validationHandler, new object[] { request });
                    await validationTask;
                }
            }

            // Run the actual request handler
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
            
            var handler = _serviceProvider.GetRequiredService(handlerType);
            var handleMethod = handler.GetType().GetMethod("HandleAsync", new[] { requestType });
            
            if (handleMethod == null)
            {
                throw new InvalidOperationException($"HandleAsync method not found on handler type {handler.GetType().Name}");
            }

            var task = (Task<TResponse>)handleMethod.Invoke(handler, new object[] { request });
            return await task;
        }

        public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command)
        {
            return SendAsync<TResponse>((IRequest<TResponse>)command);
        }

        public Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query)
        {
            return SendAsync<TResponse>((IRequest<TResponse>)query);
        }

        public async Task PublishAsync<TEvent>(TEvent evt)
        {
            var eventType = evt.GetType();
            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
            
            var handlers = _serviceProvider.GetServices(handlerType);
            
            foreach (var handler in handlers)
            {
                var handleMethod = handlerType.GetMethod(nameof(IEventHandler<TEvent>.HandleAsync));
                
                if (handleMethod == null)
                {
                    throw new InvalidOperationException($"HandleAsync method not found on handler type {handlerType.Name}");
                }

                var task = (Task)handleMethod.Invoke(handler, new object[] { evt });
                await task;
            }
        }
    }
}
