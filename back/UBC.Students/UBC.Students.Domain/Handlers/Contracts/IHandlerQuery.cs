using UBC.Students.Domain.Queries.Contracts;

namespace UBC.Students.Domain.Handlers.Contracts
{
    public interface IHandlerQuery<Q> : IHandler<Q, IQueryResult>
                        where Q : IQuery
    {
        IQueryResult Handle(Q query);
    }
}