using UBC.Students.Domain.Commands;
using UBC.Students.Domain.Entities;
using UBC.Students.Tests.Repositories;

namespace UBC.Students.Tests.Commands
{
    public class CreateStudentCommandTests
    {
        private readonly CreateStudentCommand _validCommand;
        private readonly CreateStudentCommand _invalidCommand;
        private FakeStudentRepository _studentRepository;

        public CreateStudentCommandTests()
        {
            _studentRepository = new FakeStudentRepository();
            _validCommand = new CreateStudentCommand();
            _invalidCommand = new CreateStudentCommand();
        }

        [Fact]
        public async Task Test_give_invalid_command_should_be_failAsync()
        {
            Student studentValid = new();
            var newStudent = await _studentRepository.Get(1);
            studentValid.Change(newStudent);
            studentValid.BirthDate = DateTime.Now.AddYears(-150);
            _invalidCommand.Validate();

            Assert.False(_invalidCommand.IsValid);
        }
        
        [Fact]
        public async Task Test_give_valid_command_should_be_successAsync()
        {
            Student studentValid = new();
            var newStudent = await _studentRepository.Get(1);
            studentValid.Change(newStudent);

            _validCommand.Validate();
            Assert.True(_invalidCommand.IsValid);
        }       
   
    }
}
