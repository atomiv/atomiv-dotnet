namespace Optivem.Common
{
    public interface IFactory<TResult>
    {
        TResult Create();
    }
}
