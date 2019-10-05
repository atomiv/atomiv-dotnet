namespace Optivem.Framework.Core.Common
{
    public interface IRequest
    {
    }

    public interface IRequest<TId> : IRequest
    {
        TId Id { get; set; }
    }
}