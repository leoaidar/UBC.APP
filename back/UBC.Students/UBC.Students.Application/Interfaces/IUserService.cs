
using UBC.Students.Application.ViewModels;
using UBC.Students.Domain.Queries;

namespace UBC.Users.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserViewModel> GetByLogin(LoginUserViewModel request, CancellationToken cancellationToken);
    }
}
