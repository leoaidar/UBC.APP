using System;

namespace UBC.Students.Application.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public double AverageGrade { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
