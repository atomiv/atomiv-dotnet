namespace Optivem.Core.Application
{
    public interface IUpdateRequest : IRequest
    {

    }

    public interface IUpdateRequest<TId> : IUpdateRequest, IRequest<TId>
    {
    }
}
