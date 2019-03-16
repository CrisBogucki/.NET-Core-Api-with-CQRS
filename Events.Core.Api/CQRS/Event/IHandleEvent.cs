namespace Events.Core.Api.CQRS.Event
{
    public interface IHandleEvent
    {   
    }
    
    public interface IHandleEvent<TEvent> : IHandleEvent where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}