using System.Threading.Tasks;

namespace Events.Core.Api.CQRS.Event
{
    public interface IEventBus
    {
        void PublishEvent<T>(T cmd) where T : IEvent;
        
        Task PublishEventAsync<T>(T cmd) where T : IEvent;
    }
}