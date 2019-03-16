using System;
using Events.Core.Api.CQRS.Event;

namespace Events.Core.Api.Domain.Event
{
    public class InfoMessageEventHandler_WhenInfo : IHandleEvent<MessageEvent>
    {
        public void Handle(MessageEvent @event)
        {
            Console.WriteLine($"Event info !!! {@event.Message} ");
        }
    }
}