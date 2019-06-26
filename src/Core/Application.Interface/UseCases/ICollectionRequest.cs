namespace Optivem.Framework.Core.Application
{
    public interface ICollectionRequest : IRequest
    {
        int Page { get; set; }

        int Size { get; set; }
    }
}
