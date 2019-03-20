using Events.Core.Api.CQRS.Query;

namespace Events.Core.Api.Domain.Query
{
    public class MessageQuery : IQuery
    {
        public int Id { get; set; }
    }
}