namespace Optivem.Core.Application.Requests
{
    public interface IRequest
    {

    }

    public interface IRequest<TId> : IRequest
    {
        TId Id { get; set; }
    }
}
