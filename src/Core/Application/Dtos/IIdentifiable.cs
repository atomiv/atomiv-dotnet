namespace Optivem.Core.Application
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; set; }
    }
}
