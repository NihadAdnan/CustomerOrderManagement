using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Service.Abstractions
{
    public interface IService<T>where T : class
    {
        public Task<int> AddAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(T entity);
        public IQueryable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();  
        public Task<T> GetById(Expression<Func<T, bool>> predicate);
    }
}
