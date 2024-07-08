using MediatR;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Queries;
using UBC.Students.Domain.Queries.Contracts;
using UBC.Students.Domain.Repositories;

namespace UBC.Students.Domain.Handlers
{
    public class UserQueryHandler : Handler, IRequestHandler<UserGetByLoginQuery, IQueryResult>
    {
        private readonly IUserRepository _repository;
        private readonly string _genericErrorText;
        private readonly string _genericSuccessText;

        public UserQueryHandler(IUserRepository repository) : base()
        {
            _repository = repository;
            _genericErrorText = "Ops, parece que houve algum problema com a solicitacao!";
            _genericSuccessText = "Dados retornados com sucesso!";
        }

        public async Task<IQueryResult> Handle(UserGetByLoginQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (query == null)
                    return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: _genericSuccessText));

                query.Validate();
                if (!query.IsValid)
                    return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: _genericSuccessText, data: query.Notifications));

                var userRequest = new User(0,query.Username,query.Password);
                
                userRequest.Validate();
                if (!userRequest.IsValid)
                    return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: "Usuário ou Senha inválida"));

                if (!userRequest.VerifyPassword(query.Password))
                    return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: "Usuário ou Senha inválida"));

                var userData = await _repository.GetByLogin(query.Username);

                if (userData == null)
                    return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: "Usuário ou Senha inválida"));

                if (!userData.VerifyPassword(query.Password))
                    return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: "Usuário ou Senha inválida"));

                return await Task.FromResult<IQueryResult>(new QueryResult<User>(userData, success: true, message: _genericSuccessText));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<IQueryResult>(new QueryResult<User>(null, success: false, message: _genericErrorText + "|" + ex.Message + "|" + ex.StackTrace));
            }
        }

    }
}