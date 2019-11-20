namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IRecord
    {
    }

    public interface IRecord<TId> : IRecord
    {
        TId Id { get; set; }
    }
}