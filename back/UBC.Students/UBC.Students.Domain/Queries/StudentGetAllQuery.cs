using UBC.Students.Domain.Queries.Contracts;
using MediatR;

namespace UBC.Students.Domain.Queries
{
    public class StudentGetAllQuery : IQuery, IRequest<IQueryResult>
    {
        public StudentGetAllQuery() { }
    }
}