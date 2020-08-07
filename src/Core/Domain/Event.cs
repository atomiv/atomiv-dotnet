namespace Atomiv.Core.Domain
{
    public class Event
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