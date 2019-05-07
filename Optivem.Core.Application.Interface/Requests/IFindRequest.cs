namespace Optivem.Core.Application.Requests
{
    public interface IFindRequest : IRequest
    {

    }

    public interface IFindRequest<TId> : IFindRequest, IRequest<TId>
    {
    }
}
