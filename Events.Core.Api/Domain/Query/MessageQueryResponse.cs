using Events.Core.Api.CQRS.Query;

namespace Events.Core.Api.Domain.Query
{
    public class MessageQueryResponse : IResponse
    {
        public string Message { get; set; }
    }
}