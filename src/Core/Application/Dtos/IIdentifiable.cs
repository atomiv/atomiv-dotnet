namespace Optivem.Framework.Core.Application.Ports.In.Dtos
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; set; }
    }
}
