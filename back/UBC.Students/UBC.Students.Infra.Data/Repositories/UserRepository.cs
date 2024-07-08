using Microsoft.EntityFrameworkCore;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Repositories;
using UBC.Students.Infra.Data.Contexts;

namespace UBC.Users.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task Bind<Y>(Y entities, string named)
        {
            throw new NotImplementedException();
        }

        public Task<R> GetBy<K, R>(K key)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByLogin(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x=> x.Username == username);
        }
    }
}
