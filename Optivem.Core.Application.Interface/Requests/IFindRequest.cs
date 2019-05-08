namespace Optivem.Core.Application
{
    public interface IFindRequest : IRequest
    {

    }

    public interface IFindRequest<TId> : IFindRequest, IRequest<TId>
    {
    }
}
