namespace Events.Core.Api.CQRS.Command
{
    public interface IHandleCommand
    {
        
    }
    
    public interface IHandleCommand<in TCommand> : IHandleCommand where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}