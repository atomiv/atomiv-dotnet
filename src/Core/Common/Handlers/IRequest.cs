namespace Optivem.Framework.Core.Common
{
    public interface IRequest
    {
    }

    public interface IRequest<TResponse> : IRequest
    {
    }

    public interface IRequest<TResponse, TId> : IRequest<TResponse>
    {
        TId Id { get; set; }
    }
}