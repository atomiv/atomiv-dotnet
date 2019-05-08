namespace Optivem.Core.Application
{
    public interface IFindAllRecordResponse : IResponse
    {

    }

    public interface IFindAllRecordResponse<TId> : IFindAllRecordResponse, IResponse<TId>
    {
    }
}
