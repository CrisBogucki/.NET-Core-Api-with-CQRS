namespace Events.Core.Api.CQRS.Query
{
    public interface IQueryBus
    {
        IResponse SendQuery<T>(T cmd) where T : IQuery;   
    }
}