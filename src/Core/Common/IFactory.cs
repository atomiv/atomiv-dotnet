namespace Optivem.Core.Common
{
    public interface IFactory<TResult>
    {
        TResult Create();
    }
}
