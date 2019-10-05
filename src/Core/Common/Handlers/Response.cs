namespace Optivem.Framework.Core.Common
{
    public abstract class Response : IResponse
    {
    }

    public abstract class Response<TId> : IResponse<TId>
    {
        public TId Id { get; set; }
    }
}
