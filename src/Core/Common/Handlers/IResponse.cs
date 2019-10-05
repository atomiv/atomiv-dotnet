namespace Optivem.Framework.Core.Common
{
    public interface IResponse
    {
    }

    public interface IResponse<TId> : IResponse
    {
        TId Id { get; set; }
    }
}