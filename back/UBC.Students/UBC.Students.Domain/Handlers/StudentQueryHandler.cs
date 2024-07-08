using MediatR;
using UBC.Students.Domain.Domain.Entities;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Queries;
using UBC.Students.Domain.Queries.Contracts;
using UBC.Students.Domain.Repositories;

namespace UBC.Students.Domain.Handlers
{
    public class StudentQueryHandler : Handler, IRequestHandler<StudentGetAllQuery, IQueryResult>, IRequestHandler<StudentGetQuery, IQueryResult>
    {
        private readonly IRepository<Student> _repository;
        private readonly string _genericErrorText;
        private readonly string _genericSuccessText;

        public StudentQueryHandler(IRepository<Student> repository) : base()
        {
            _repository = repository;
            _genericErrorText = "Ops, parece que houve algum problema com a solicitacao!";
            _genericSuccessText = "Dados retornados com sucesso!";
        }

        public async Task<IQueryResult> Handle(StudentGetAllQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var students = await _repository.GetAll();

                return await Task.FromResult<IQueryResult>(new QueryResult<IEnumerable<Student>>(students, success: true, message: _genericSuccessText));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<IQueryResult>(new QueryResult<IEnumerable<Student>>(null, success: false, message: _genericErrorText + "|" + ex.Message + "|" + ex.StackTrace));
            }
        }

        public async Task<IQueryResult> Handle(StudentGetQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (query == null)
                    return await Task.FromResult<IQueryResult>(new QueryResult<Student>(null, success: false, message: _genericSuccessText));

                query.Validate();
                if (!query.IsValid)
                    return await Task.FromResult<IQueryResult>(new QueryResult<Student>(null, success: false, message: _genericSuccessText, data: query.Notifications));

                var student = await _repository.Get(query.Id);

                if (student == null)
                    return await Task.FromResult<IQueryResult>(new QueryResult<Student>(null, success: false, message: "Usuário nao encontrado"));

                return await Task.FromResult<IQueryResult>(new QueryResult<Student>(student, success: true, message: _genericSuccessText));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<IQueryResult>(new QueryResult<Student>(null, success: false, message: _genericErrorText + "|" + ex.Message + "|" + ex.StackTrace));
            }
        }

    }
}