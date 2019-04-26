using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Core.Api.CQRS.Extensions;

namespace Events.Core.Api.CQRS.Event.Code
{
    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> _handlersFactory;

        public EventBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void PublishEvent<T>(T cmd) where T : IEvent
        {
            // Logging
            // Auth
            // validate
            // error handling
            // ...
            var handlers = _handlersFactory(typeof(T)).Cast<IHandleEvent<T>>();
            foreach (var handler in handlers)
            {
                using (new Performance<T>())
                {
                    handler.Handle(cmd);
                }
            }
        }
        
        public async Task PublishEventAsync<T>(T cmd) where T : IEvent
        {
            var handlers = _handlersFactory(typeof(T)).Cast<IHandleEvent<T>>();
            foreach (var handler in handlers)
            {                
                await Task.Run(() =>
                {
                    using (new Performance<T>())
                    {
                        handler.Handle(cmd);
                    }
                });
            }
        }
    }
}