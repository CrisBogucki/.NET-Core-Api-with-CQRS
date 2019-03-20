using System;
using System.Threading.Tasks;

namespace Events.Core.Api.CQRS.Command.Code
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;

        public CommandBus(Func<Type, IHandleCommand> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void SendCommand<T>(T cmd) where T : ICommand
        {
            // logging
            // auth
            // validate
            // measure time
            // error handling
            // ...

            var handler = (IHandleCommand<T>) _handlersFactory(typeof(T));
            handler.Handle(cmd);
        }

        public async Task SendCommandAsync<T>(T cmd) where T : ICommand
        {
            await Task.Run(() =>
            {
                try
                {
                    var handler = (IHandleCommand<T>) _handlersFactory(typeof(IHandleCommand<T>));
                    handler.Handle(cmd);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            });
        }
    }
}