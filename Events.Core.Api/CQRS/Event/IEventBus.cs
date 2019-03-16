namespace Events.Core.Api.CQRS.Event
{
    public interface IEventBus
    {
        void PublishEvent<T>(T cmd) where T : IEvent;
    }
}