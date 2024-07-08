namespace UBC.Students.Domain.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> Get(int id);

        public Task<R> GetBy<K,R>(K key);

        public Task<T> Create(T item);

        public Task Update(T item);

        public Task Delete(int id);

        public Task Bind<Y>(Y entities, string named = null);
    }
}

