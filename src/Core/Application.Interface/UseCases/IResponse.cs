namespace Optivem.Framework.Core.Application
{
    public interface IResponse
    {
    }

    public interface IResponse<TId> : IResponse
    {
        TId Id { get; set; }
    }
}