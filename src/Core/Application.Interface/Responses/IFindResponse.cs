namespace Optivem.Core.Application
{
    public interface IFindResponse : IResponse
    {

    }

    public interface IFindResponse<TId> : IFindResponse, IResponse<TId>
    {
    }
}
