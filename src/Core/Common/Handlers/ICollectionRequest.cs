namespace Optivem.Framework.Core.Common
{
    public interface ICollectionRequest : IRequest
    {
        int Page { get; set; }

        int Size { get; set; }
    }
}
