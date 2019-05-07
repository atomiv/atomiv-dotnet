namespace Optivem.Core.Application.Responses
{
    public interface IUpdateResponse : IResponse
    {

    }

    public interface IUpdateResponse<TId> : IUpdateResponse, IResponse<TId>
    {
    }
}
