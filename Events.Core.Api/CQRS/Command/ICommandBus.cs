using System.Threading.Tasks;

namespace Events.Core.Api.CQRS.Command
{
    public interface ICommandBus
    {
        
        void SendCommand<T>(T cmd) where T : ICommand;
        
        Task SendCommandAsync<T>(T cmd) where T : ICommand;
        
    }
}