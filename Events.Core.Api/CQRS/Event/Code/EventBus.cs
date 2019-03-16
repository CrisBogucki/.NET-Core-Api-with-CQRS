using System;
using System.Collections.Generic;
using System.Linq;

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
            // measure time
            // error handling
            // ...
            
            var handlers = _handlersFactory(typeof(T)).Cast<IHandleEvent<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(cmd);
            }
        }
    }
}