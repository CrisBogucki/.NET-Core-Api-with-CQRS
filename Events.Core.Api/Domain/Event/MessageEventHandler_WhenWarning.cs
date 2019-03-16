using System;
using Events.Core.Api.CQRS.Event;

namespace Events.Core.Api.Domain.Event
{
    public class WarningMessageEventHandler_WhenWarning : IHandleEvent<MessageEvent>
    {
        public void Handle(MessageEvent @event)
        {
            Console.WriteLine($"Event warning !!! {@event.Message} ");
        }
    }
}