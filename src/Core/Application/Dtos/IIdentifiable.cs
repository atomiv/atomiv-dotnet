namespace Optivem.Framework.Core.Application.Ports.Dtos
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; set; }
    }
}
