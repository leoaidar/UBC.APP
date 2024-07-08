using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using UBC.Students.Domain.Commands.Contracts;

namespace UBC.Students.Domain.Commands
{
    public class LoginUserCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public LoginUserCommand() { }

        public LoginUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsLowerOrEqualsThan(Username, 1, "Body", "Por favor, digite o conteudo da mensagem!")
                    .IsLowerOrEqualsThan(Password, 1, "ServiceId", "Por favor, digite o identificador do serviço!")
            );            
        }
    }
}