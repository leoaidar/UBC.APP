using System.ComponentModel.DataAnnotations.Schema;
using UBC.Students.Domain.Domain.Entities;

namespace UBC.Students.Domain.Entities
{
    [Table("Students")]
    public class Student : Entity
    {
        public int Id { get; set; } = default(int);
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public double AverageGrade { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(){}

        public Student(int id, string name, int age, int grade, double averageGrade, string address, string fatherName, string motherName, DateTime birthDate) : base()
        {
            Id = id;
            Name = name;
            Age = age;
            Grade = grade;
            AverageGrade = averageGrade;
            Address = address;
            FatherName = fatherName;
            MotherName = motherName;
            BirthDate = birthDate;
            Validate();
        }

        public override void Validate()
        {
            IsValid = true;
            if (string.IsNullOrEmpty(Name?.Trim()))
                IsValid = false;
            if (Age <= 0)
                IsValid = false;
            if (Grade < 1)
                IsValid = false;
            if (AverageGrade < 0.0 || AverageGrade > 10.0)
                IsValid = false;
            if (string.IsNullOrEmpty(Address?.Trim()))
                IsValid = false;
            if (string.IsNullOrEmpty(FatherName?.Trim()))
                IsValid = false;
            if (string.IsNullOrEmpty(MotherName?.Trim()))
                IsValid = false;
            if (BirthDate > DateTime.Now)
                IsValid = false;
        }

        public void Change(Student newCharacteristics)
        {
            Name = newCharacteristics.Name;
            Age = newCharacteristics.Age;
            Grade = newCharacteristics.Grade;
            AverageGrade = newCharacteristics.AverageGrade;
            Address = newCharacteristics.Address;
            FatherName = newCharacteristics.FatherName;
            MotherName = newCharacteristics.MotherName;
            BirthDate = newCharacteristics.BirthDate;
        }
    }
}
