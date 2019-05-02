using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application.UseCases
{
    public interface IIdentifiableRequest<TResponse, TKey> : IRequest<TResponse>
    {
        TKey Id { get; set; }
    }
}
