namespace Optivem.Core.Application.Requests
{
    public interface IDeleteRequest : IRequest
    {

    }

    public interface IDeleteRequest<TId> : IDeleteRequest, IRequest<TId> 
    {
    }
}
