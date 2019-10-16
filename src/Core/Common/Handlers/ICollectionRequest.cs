namespace Optivem.Framework.Core.Common
{
    public interface ICollectionRequest<TResponse> : IRequest<TResponse>
    {
        int Page { get; set; }

        int Size { get; set; }
    }
}