using MediatR;
using Optivem.Framework.Core.Common;
using IRequest = Optivem.Framework.Core.Common.IRequest;

namespace Optivem.Framework.Infrastructure.MediatR
{
    public class MediatorRequest<TRequest, TResponse> : IMediatorRequest<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public TRequest Request { get; set; }
    }
}