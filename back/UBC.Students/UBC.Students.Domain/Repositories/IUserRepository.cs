using UBC.Students.Domain.Entities;

namespace UBC.Students.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByLogin(string username);
    }
}

