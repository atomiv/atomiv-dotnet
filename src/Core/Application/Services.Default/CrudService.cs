using AutoMapper;
using MediatR;
using Optivem.Framework.Core.Application.UseCases;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services.Default
{
    public class CrudService<TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TEntity, TKey> 
        : ICrudService<TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TKey>
        where TFindAllRequest : IRequest<IEnumerable<TFindAllResponse>>, new()
        where TFindRequest : IIdentifiableRequest<TFindResponse, TKey>, new()
        where TCreateRequest : IRequest<TCreateResponse>
        where TUpdateRequest : IIdentifiableRequest<bool, TKey>, new()
        where TDeleteRequest : IIdentifiableRequest<bool, TKey>, new()
        where TEntity : class, IEntity<TKey>
    {
        public CrudService(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; private set; }

        public Task<IEnumerable<TFindAllResponse>> FindAllAsync()
        {
            var request = new TFindAllRequest();
            return Mediator.Send(request);
        }

        public Task<TFindResponse> FindAsync(TKey id)
        {
            var request = new TFindRequest()
            {
                Id = id,
            };

            return Mediator.Send(request);
        }

        public Task<TCreateResponse> CreateAsync(TCreateRequest request)
        {
            return Mediator.Send(request);
        }

        public Task<bool> UpdateAsync(TUpdateRequest request)
        {
            return Mediator.Send(request);
        }

        public Task<bool> DeleteAsync(TKey id)
        {
            var request = new TDeleteRequest
            {
                Id = id,
            };

            return Mediator.Send(request);
        }
    }
}
