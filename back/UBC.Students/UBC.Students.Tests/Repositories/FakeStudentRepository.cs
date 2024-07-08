using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Repositories;

namespace UBC.Students.Tests.Repositories
{
    public class FakeStudentRepository : IRepository<Student>
    {
        private List<Student> _list;

        public FakeStudentRepository()
        {
            _list = new List<Student>{
                new Student(1, "Leonardo", 38, 6, 9.9, "Brazil", "Silva", "Batista", DateTime.Now.AddYears(-38)),
                new Student(2, "Mark", 9, 4, 9.3, "3636 Oak St", "Mark Brown", "Sophia Brown", DateTime.Parse("2014-01-12")),
                new Student(3, "Nina", 10, 5, 8.7, "3737 Pine St", "Nina Smith", "Olivia Smith", DateTime.Parse("2013-05-17")),
                new Student(4, "Oscar", 11, 6, 7.9, "3838 Birch St", "Oscar Turner", "Emily Turner", DateTime.Parse("2012-09-30")),
                new Student(5, "Paula", 9, 4, 9.4, "3939 Elm St", "Paula Harris", "John Harris", DateTime.Parse("2014-03-11")),
                new Student(6, "Quincy", 10, 5, 8.1, "4040 Cedar St", "Quincy Davis", "Daniel Davis", DateTime.Parse("2013-04-01"))
            };
        }
        public Task Bind<Y>(Y entities, string named = null)
        {
            if (named.Equals("Students"))
                _list = entities as List<Student>;

            return Task.FromResult<bool>(true);
        }

        public Task<Student> Create(Student item)
        {
            return Task.FromResult<Student>(item);
        }

        public Task Delete(int id)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<Student> Get(int id)
        {
            return Task.FromResult<Student>(_list.FirstOrDefault(x=> x.Id == id));
        }

        public Task<R> GetBy<K, R>(K key)
        {
            throw new NotImplementedException();
        }

        public Task Update(Student item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            return Task.FromResult<IEnumerable<Student>>(_list);
        }
    }
}