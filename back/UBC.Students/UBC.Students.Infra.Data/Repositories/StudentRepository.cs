using Microsoft.EntityFrameworkCore;
using UBC.Students.Domain.Domain.Entities;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Repositories;
using UBC.Students.Infra.Data.Contexts;

namespace UBC.Students.Infra.Data.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> Create(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Student entity)
        {
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Students.FindAsync(id);
            _context.Students.Remove(entity);
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
    }
}
