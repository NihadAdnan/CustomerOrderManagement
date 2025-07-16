using CustomerOrderManagement.Models;
using System.Linq.Expressions;

namespace CustomerOrderManagement.Repository.Abstractions
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task<int> AddAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(T entity);
        public Task<T> GetById(Expression<Func<T, bool>> predicate);
        public IQueryable<T> GetAll();
        public Task<IEnumerable<T>>GetAllAsync();
    }
}
