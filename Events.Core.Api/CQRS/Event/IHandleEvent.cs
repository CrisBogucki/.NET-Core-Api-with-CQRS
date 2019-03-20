namespace Events.Core.Api.CQRS.Event
{
    public interface IHandleEvent
    {   
    }
    
    public interface IHandleEvent<in TEvent> : IHandleEvent where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}