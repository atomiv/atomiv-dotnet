namespace Optivem.Core.Application
{
    public interface IDeleteRequest : IRequest
    {
    }

    public interface IDeleteRequest<TId> : IDeleteRequest, IRequest<TId>
    {
    }
}