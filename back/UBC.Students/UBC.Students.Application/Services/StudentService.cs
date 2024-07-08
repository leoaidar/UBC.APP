using AutoMapper;
using MediatR;
using UBC.Students.Application.Interfaces;
using UBC.Students.Application.ViewModels;
using UBC.Students.Domain.Commands;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Queries;

namespace UBC.Students.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public StudentService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var handler = (QueryResult<IEnumerable<Student>>)await (_mediator.Send(new StudentGetAllQuery(), cancellationToken));

            var collection = _mapper.Map<IEnumerable<StudentViewModel>>(handler.Entity);

            return collection;
        }

        public async Task<StudentViewModel> Get(int id, CancellationToken cancellationToken)
        {
            var handler = (QueryResult<Student>)await (_mediator.Send(new StudentGetQuery(id), cancellationToken));

            var entity = _mapper.Map<StudentViewModel>(handler.Entity);

            return entity;
        }

        public async Task<CommandResult> Create(CreateStudentViewModel request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateStudentCommand>(request);

            var handler = (CommandResult) await _mediator.Send(command, cancellationToken);

            var viewModel = _mapper.Map<StudentViewModel>(handler.Data);

            handler.Data = viewModel;

            return handler;
        }

        public async Task<CommandResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteStudentCommand(id);

            var handler = (CommandResult) await _mediator.Send(command, cancellationToken);

            return handler;
        }

        public async Task<CommandResult> Update(int id, CreateStudentViewModel request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateStudentCommand>(request);
            command.Id = id;

            var handler = (CommandResult)await _mediator.Send(command, cancellationToken);

            var viewModel = _mapper.Map<StudentViewModel>(handler.Data);

            handler.Data = viewModel;

            return handler;
        }
    }

}
