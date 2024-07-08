using UBC.Students.Domain.Entities;

namespace UBC.Students.Tests.EntitiesTests
{
    public class StudentTests
    {
        private Student _validStudent;

        public StudentTests()
        {
            _validStudent = new Student 
            { 
                Name = "Forrest!", 
                MotherName = "Mommy", 
                FatherName = "Daddy", 
                Age = 29, 
                Address = "Marte", 
                Grade = 5, 
                AverageGrade = 7.9, 
                BirthDate = DateTime.Now.AddYears(-29), 
                CreatedDate = DateTime.Now, 
                LastUpdatedDate = DateTime.Now 
            };
        }

        [Fact]
        public void Test_Student_should_have_a_creation_date()
        {
            _validStudent.Validate();
            Assert.False(!_validStudent.IsValid);
            Assert.Equal(_validStudent.CreatedDate == null, false);
            Assert.True(_validStudent.CreatedDate.HasValue);
        }

        [Fact]
        public void Test_Student_must_be_Invalid_when_name_is_empty()
        {
            var Student = _validStudent;
            Student.Name = string.Empty;
            Student.Validate();
            Assert.True(Student.Name == string.Empty);
            Assert.False(Student.IsValid);
        }

        [Fact]
        public void Test_Student_must_be_Invalid_when_text_name_is_empty()
        {
            var Student = _validStudent;
            Student.Name = "";
            Student.Validate();
            Assert.True(Student.Name.Equals(""));
            Assert.False(Student.IsValid);
        }

        [Fact]
        public void Test_Student_must_be_Invalid_when_text_name_is_only_space()
        {
            var Student = _validStudent;
            Student.Name = " ";
            Student.Validate();
            Assert.True(Student.Name.Equals(" "));
            Assert.False(Student.IsValid);
        }

        [Fact]
        public void Test_Student_must_be_Invalid_when_name_is_null()
        {
            var Student = _validStudent;
            Student.Name = null;
            Student.Validate();
            Assert.True(Student.Name == null);
            Assert.False(Student.IsValid);
        }
    }
}
