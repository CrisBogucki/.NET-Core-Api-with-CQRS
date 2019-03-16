using System;
using Events.Core.Api.CQRS.Event;

namespace Events.Core.Api.Domain.Event
{
    public class MessageEvent : IEvent
    {
        public DateTime Date { get; set; }
        
        public string Message { get; set; }
        
    }
}