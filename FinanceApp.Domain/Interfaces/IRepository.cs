

namespace FinanceApp.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public IEnumerable<T> GetAll();
    }
}