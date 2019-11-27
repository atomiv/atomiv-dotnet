namespace Optivem.Framework.Core.Domain
{
    public class Event
    {
    }

    public class Event<TId> : Event
    {
        public TId Id { get; set; }
    }
}