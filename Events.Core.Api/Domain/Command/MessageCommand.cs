using Events.Core.Api.CQRS.Command;

namespace Events.Core.Api.Domain.Command
{
    public class MessageCommand : ICommand
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public int Delay { get; set; }
    }
}