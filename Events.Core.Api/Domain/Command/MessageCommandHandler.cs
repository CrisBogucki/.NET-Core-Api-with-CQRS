using System;
using System.Threading;
using System.Threading.Tasks;
using Events.Core.Api.CQRS.Command;
using Events.Core.Api.CQRS.Event;
using Events.Core.Api.Domain.Event;

namespace Events.Core.Api.Domain.Command
{
    public class MessageCommandHandler : IHandleCommand<MessageCommand>
    {
        private readonly IEventBus _eventsBus;

        public MessageCommandHandler(IEventBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        public void Handle(MessageCommand command)
        {
            
            Console.WriteLine($"<- command {command.Title}");

  
        }
    }
}