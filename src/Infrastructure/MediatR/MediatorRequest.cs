using MediatR;
using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Infrastructure.MediatR
{
    public class MediatorRequest<TRequest, TResponse> : IMediatorRequest<TRequest, TResponse>
        where TRequest : Core.Common.IRequest<TResponse>
    {
        public TRequest Request { get; set; }
    }
}