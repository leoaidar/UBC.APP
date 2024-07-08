using UBC.Students.Domain.Queries.Contracts;
using MediatR;
using Flunt.Notifications;
using Flunt.Validations;

namespace UBC.Students.Domain.Queries
{
    public class UserGetByLoginQuery : Notifiable<Notification>, IQuery, IRequest<IQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserGetByLoginQuery() { }

        public UserGetByLoginQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                        .Requires()
                        .IsNotNullOrEmpty(Username?.Trim(), "Username", "Por favor, digite o usuário!") 
                        .IsNotNullOrEmpty(Password?.Trim(), "Password", "Por favor, digite a senha!")
            );
        }
    }
}