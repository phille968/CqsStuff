namespace FunctionApp.Domain.Core
{
    public interface IQueries
    {
        TQuery Get<TQuery>() where TQuery : IQuery<TQuery>;
    }
}