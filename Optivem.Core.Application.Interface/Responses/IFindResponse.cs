namespace Optivem.Core.Application.Responses
{
    public interface IFindResponse : IResponse
    {

    }

    public interface IFindResponse<TId> : IFindResponse, IResponse<TId>
    {
    }
}
