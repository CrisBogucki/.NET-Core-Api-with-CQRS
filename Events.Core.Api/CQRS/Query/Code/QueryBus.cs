using System;
using Events.Core.Api.CQRS.Command;

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
            // measure time
            // error handling
            // ...

            var handler = (IHandleQuery<IResponse, T>) _handlersFactory(typeof(T));
            return handler.Handle(cmd);
        }
    }
}