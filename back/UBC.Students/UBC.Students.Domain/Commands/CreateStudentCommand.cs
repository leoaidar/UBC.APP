using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System.Text.Json.Serialization;
using UBC.Students.Domain.Commands.Contracts;

namespace UBC.Students.Domain.Commands
{
    public class CreateStudentCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public double AverageGrade { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateStudentCommand() { }

        public CreateStudentCommand(string name, int age, int grade, double averageGrade,
                                      string address, string fatherName, string motherName, DateTime birthDate)
        {
            Name = name;
            Age = age;
            Grade = grade;
            AverageGrade = averageGrade;
            Address = address;
            FatherName = fatherName;
            MotherName = motherName;
            BirthDate = birthDate;
        }
        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(Name, "Body", "Por favor, digite o conteudo!")
                    .IsNotNullOrEmpty(Address, "Address", "Por favor, digite o conteudo!")
                    .IsNotNullOrEmpty(FatherName, "FatherName", "Por favor, digite o conteudo!")
                    .IsNotNullOrEmpty(MotherName, "MotherName", "Por favor, digite o conteudo!")
                    .IsGreaterThan(Age, 0, "Age")
                    .IsBetween(AverageGrade, 0.0, 10.0, "AverageGrade")
                    .IsGreaterThan(BirthDate, DateTime.Now.AddYears(-100), "BirthDate")
            );            
        }
    }
}