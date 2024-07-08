using UBC.Students.Domain.Queries.Contracts;

namespace UBC.Students.Domain.Queries
{
    public class QueryResult<T> : IQueryResult
    {
        public QueryResult() { }

        public QueryResult(T entity, IEnumerable<T> entities = null, bool success = true, string message = "", object data = null) : base()
        {
            Success = success;
            Message = message;
            Data = data;
            Entity = entity;
            Entities = entities;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public T Entity { get; set; }
        public IEnumerable<T> Entities { get; set; }

        public static explicit operator QueryResult<T>(Task<IQueryResult> v)
        {
            throw new NotImplementedException();
        }
    }
}