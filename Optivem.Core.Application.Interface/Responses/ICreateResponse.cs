namespace Optivem.Core.Application
{
    public interface ICreateResponse : IResponse
    {

    }

    public interface ICreateResponse<TId> : ICreateResponse, IResponse<TId>
    {
    }
}
