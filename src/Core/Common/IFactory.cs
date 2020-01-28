namespace Optivem.Atomiv.Core.Common
{
    public interface IFactory<TResult>
    {
        TResult Create();
    }
}