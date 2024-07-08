using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using UBC.Students.Domain.Commands.Contracts;

namespace UBC.Students.Domain.Commands
{
    public class UpdateStudentCommand : CreateStudentCommand, ICommand, IRequest<ICommandResult>
    {
        public int Id { get; set; }

        public UpdateStudentCommand() { }

        public UpdateStudentCommand(int id) : base()
        {
            Id = id;
        }
    }
}