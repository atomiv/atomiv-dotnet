namespace Optivem.Core.Application.Responses
{
    public interface IResponse
    {

    }

    public interface IResponse<TId> : IResponse
    {
        TId Id { get; set; }
    }
}
