using UBC.Students.Domain.Commands;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Handlers;
using UBC.Students.Domain.Repositories;
using UBC.Students.Tests.Repositories;

namespace UBC.Students.Tests.HandlerTests
{
    public class StudentCommandHandlerTests
    {
        private IRepository<Student> _repo;
        private StudentCommandHandler _handler;
        private readonly DeleteStudentCommand _validDeleteCommand;
        private readonly DeleteStudentCommand _invalidDeleteCommand;

        private CommandResult _result;

        public StudentCommandHandlerTests()
        {
            _repo = new FakeStudentRepository();
            _handler = new StudentCommandHandler(_repo);
            _result = new CommandResult();

            _validDeleteCommand = new DeleteStudentCommand(1);
            _invalidDeleteCommand = new DeleteStudentCommand(-1);
        }

        [Fact]
        public void Test_give_invalid_delete_command_must_stop_execution()
        {
            var command = _handler.Handle(_invalidDeleteCommand, new System.Threading.CancellationToken());
            _result = (CommandResult)command.Result;
            Assert.Equal(_result.Success, false);
        }
        
        [Fact]
        public void Test_give_valid_delete_command_should_remove_success()
        {
            var command = _handler.Handle(_validDeleteCommand, new System.Threading.CancellationToken());
            _result = (CommandResult)command.Result;
            Assert.Equal(_result.Success, true);
        }
    }
}