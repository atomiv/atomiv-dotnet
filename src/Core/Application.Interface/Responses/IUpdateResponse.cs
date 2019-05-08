namespace Optivem.Core.Application
{
    public interface IUpdateResponse : IResponse
    {

    }

    public interface IUpdateResponse<TId> : IUpdateResponse, IResponse<TId>
    {
    }
}
