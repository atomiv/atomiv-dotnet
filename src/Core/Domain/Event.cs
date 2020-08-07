namespace Atomiv.Core.Domain
{
    public class Event : IEvent
    {
    }

    public class Event<TId> : Event
    {
        public Event(TId id)
        {
            Id = id;
        }

        public TId Id { get; }
    }
}