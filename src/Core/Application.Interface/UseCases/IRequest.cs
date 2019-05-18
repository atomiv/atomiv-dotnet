namespace Optivem.Core.Application
{
    public interface IRequest
    {

    }

    public interface IRequest<TId> : IRequest
    {
        TId Id { get; set; }
    }
}
