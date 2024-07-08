using UBC.Students.Domain.Queries.Contracts;
using MediatR;
using Flunt.Notifications;
using Flunt.Validations;

namespace UBC.Students.Domain.Queries
{
    public class StudentGetQuery : Notifiable<Notification>, IQuery, IRequest<IQueryResult>
    {
        public int Id { get; set; }

        public StudentGetQuery() { }

        public StudentGetQuery(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                        .Requires()
                        .IsNotNull(Id, "Id", "Por favor, informe o id!")
                        .IsGreaterThan(Id, 0, "Por favor, informe o id!")
            );
        }
    }
}