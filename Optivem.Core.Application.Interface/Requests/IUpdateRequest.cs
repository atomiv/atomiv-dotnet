namespace Optivem.Core.Application.Requests
{
    public interface IUpdateRequest : IRequest
    {

    }

    public interface IUpdateRequest<TId> : IUpdateRequest, IRequest<TId>
    {
    }
}
