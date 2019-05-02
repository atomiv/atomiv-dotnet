namespace Optivem.Framework.Core.Application.UseCases
{
    public interface IIdentifiableResponse<TKey>
    {
        TKey Id { get; set; }
    }
}
