namespace Events.Core.Api.CQRS.Query
{
    public interface IHandleQuery
    {
        
    }
    
    public interface IHandleQuery<out TResponse, in TQuery> : IHandleQuery where TQuery : IQuery where TResponse : IResponse
    {
        TResponse Handle(TQuery query);
    }
}