using System;
using System.Threading.Tasks;
using Events.Core.Api.CQRS.Tools;

namespace Events.Core.Api.CQRS.Query.Code
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IHandleQuery> _handlersFactory;

        public QueryBus(Func<Type, IHandleQuery> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public IResponse SendQuery<T>(T cmd) where T : IQuery
        {
            // logging
            // auth
            // validate
            // error handling
            // ...

            using (new Performance<T>())
            {
                var handler = (IHandleQuery<IResponse, T>) _handlersFactory(typeof(T));
                return handler.Handle(cmd);
            }
        }

        public async Task<IResponse> SendQueryAsync<T>(T cmd) where T : IQuery
        {
            return await Task.Run(() =>
            {
                using (new Performance<T>())
                {
                    var handler = (IHandleQuery<IResponse, T>) _handlersFactory(typeof(T));
                    return handler.Handle(cmd);
                }
            });
        }
    }
}