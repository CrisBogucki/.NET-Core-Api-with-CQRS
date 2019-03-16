using System;
using System.Threading;
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
            Console.WriteLine("");
            Console.WriteLine($"Command {command.Title}");

            var msg = new MessageEvent()
            {
                Date = DateTime.Now, // get date from regex
                Message = command.Message + " to events"
            };

            _eventsBus.PublishEvent(msg);
        }
    }
}