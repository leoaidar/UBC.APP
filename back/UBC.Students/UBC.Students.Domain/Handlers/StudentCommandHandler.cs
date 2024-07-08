using AutoMapper;
using MediatR;
using UBC.Students.Domain.Commands;
using UBC.Students.Domain.Commands.Contracts;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Repositories;

namespace UBC.Students.Domain.Handlers
{
    public class StudentCommandHandler : Handler, IRequestHandler<CreateStudentCommand, ICommandResult>, IRequestHandler<DeleteStudentCommand, ICommandResult>, IRequestHandler<UpdateStudentCommand, ICommandResult>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;
        private readonly string _genericErrorText;
        private readonly string _genericSuccessText;

        public StudentCommandHandler(IRepository<Student> repository) : base()
        {
            _repository = repository;
            _genericErrorText = "Ops, parece que os dados da mensagem estão errados!";
            _genericSuccessText = "Dados salvos com sucesso!";
        }

        public StudentCommandHandler(IRepository<Student> repository, IMapper mapper, string genericErrorText, string genericSuccessText) : this(repository)
        {
            _mapper = mapper;
            _genericErrorText = genericErrorText;
            _genericSuccessText = genericSuccessText;
        }

        public async Task<ICommandResult> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, null));

                command.Validate();
                if (!command.IsValid)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, command.Notifications));

                var student = new Student(0,command.Name, command.Age, command.Grade, command.AverageGrade, command.Address, command.FatherName, command.MotherName, command.BirthDate);

                student.Validate();
                if (!student.IsValid)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, "Regra de negócio inválida"));

                await _repository.Create(student);

                return await Task.FromResult<ICommandResult>(new CommandResult(true, _genericSuccessText, student));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText + "|" + ex.Message + "|" + ex.StackTrace, null));
            }
        }

        public async Task<ICommandResult> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, null));

                command.Validate();
                if (!command.IsValid)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, command.Notifications));

                var student = await _repository.Get(command.Id);

                if (student == null)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, command.Notifications));

                await _repository.Delete(student.Id);

                return await Task.FromResult<ICommandResult>(new CommandResult(true, "Dados deletados com sucesso!", null));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText + "|" + ex.Message + "|" + ex.StackTrace, null));
            }
        }

        public async Task<ICommandResult> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, null));

                if (command.Id <= 0)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, null));

                command.Validate();
                if (!command.IsValid)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, command.Notifications));

                var studentData = await _repository.Get(command.Id);

                if (studentData == null)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, command.Notifications));

                var student = new Student(studentData.Id, command.Name, command.Age, command.Grade, command.AverageGrade, command.Address, command.FatherName, command.MotherName, command.BirthDate);

                student.Validate();
                if (!student.IsValid)
                    return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText, "Regra de negócio inválida"));

                studentData.Change(student);

                await _repository.Update(studentData);

                return await Task.FromResult<ICommandResult>(new CommandResult(true, _genericSuccessText, student));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<ICommandResult>(new CommandResult(false, _genericErrorText + "|" + ex.Message + "|" + ex.StackTrace, null));
            }
        }
    }
}