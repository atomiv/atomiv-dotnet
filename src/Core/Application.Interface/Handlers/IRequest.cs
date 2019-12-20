namespace Optivem.Framework.Core.Application
{
    public interface IRequest
    {
    }

    public interface IRequest<TResponse> : IRequest
    {
    }
}