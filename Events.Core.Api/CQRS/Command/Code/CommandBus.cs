using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Events.Core.Api.CQRS.Tools;

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
            // error handling
            // ...

            using (new Performance<T>())
            {
                var handler = (IHandleCommand<T>) _handlersFactory(typeof(T));
                handler.Handle(cmd);
            }
        }

        public async Task SendCommandAsync<T>(T cmd) where T : ICommand
        {
            await Task.Run(() =>
            {
                using (new Performance<T>())
                {
                    var handler = (IHandleCommand<T>) _handlersFactory(typeof(IHandleCommand<T>));
                    handler.Handle(cmd);
                }
            });
        }
    }
}