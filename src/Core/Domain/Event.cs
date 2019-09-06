namespace Optivem.Framework.Core.Domain
{
    public class Event : IEvent
    {
    }

    public class Event<TId> : Event, IEvent<TId>
    {
        public TId Id { get; set; }
    }
}
