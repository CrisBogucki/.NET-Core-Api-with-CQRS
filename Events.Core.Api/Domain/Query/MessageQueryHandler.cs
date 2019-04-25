using System;
using Events.Core.Api.CQRS.Query;

namespace Events.Core.Api.Domain.Query
{
    public class MessageQueryHandler : IHandleQuery<MessageQueryResponse, MessageQuery>
    {
        public MessageQueryResponse Handle(MessageQuery query)
        {
            Console.WriteLine($"<- query {query.Id} ");
            return new MessageQueryResponse(){ Message = @"Odpowiedź z Query " + query.Id};
        }
    }
}