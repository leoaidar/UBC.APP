using UBC.Students.Domain.Commands;

namespace UBC.Students.Tests.Commands
{
    public class DeleteStudentCommandTests
    {
        private readonly DeleteStudentCommand _validCommand;
        private readonly DeleteStudentCommand _invalidCommand;

        public DeleteStudentCommandTests()
        {
            _validCommand = new DeleteStudentCommand(1);
            _invalidCommand = new DeleteStudentCommand(-1);
        }

        [Fact]
        public void Test_give_invalid_command_should_be_fail()
        {
            _invalidCommand.Validate();
            Assert.Equal(_invalidCommand.IsValid, false);
        }
        
        [Fact]
        public void Test_give_valid_command_should_be_success()
        {
            _validCommand.Validate();
            Assert.Equal(_invalidCommand.IsValid, true);
        }        
   
    }
}
