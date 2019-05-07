namespace Optivem.Core.Application.Responses
{
    public interface ICreateResponse : IResponse
    {

    }

    public interface ICreateResponse<TId> : ICreateResponse, IResponse<TId>
    {
    }
}
