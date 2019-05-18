namespace Optivem.Core.Application
{
    public interface IResponse
    {

    }

    public interface IResponse<TId> : IResponse
    {
        TId Id { get; set; }
    }
}
