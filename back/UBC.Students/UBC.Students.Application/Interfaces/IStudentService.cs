using UBC.Students.Application.ViewModels;
using UBC.Students.Domain.Commands;

namespace UBC.Students.Application.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentViewModel>> GetAll(CancellationToken cancellationToken);

        public Task<StudentViewModel> Get(int id, CancellationToken cancellationToken);

        public Task<CommandResult> Create(CreateStudentViewModel request, CancellationToken cancellationToken);

        public Task<CommandResult> Delete(int id, CancellationToken cancellationToken);

        public Task<CommandResult> Update(int id, CreateStudentViewModel request, CancellationToken cancellationToken);
    }
}
