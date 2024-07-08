using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using UBC.Students.Domain.Commands.Contracts;

namespace UBC.Students.Domain.Commands
{
    public class DeleteStudentCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public int Id { get; set; }

        public DeleteStudentCommand() { }

        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Id, "Id", "Por favor, digite o conteudo!")
                    .IsGreaterThan(Id, 0, "Id")
            );            
        }
    }
}