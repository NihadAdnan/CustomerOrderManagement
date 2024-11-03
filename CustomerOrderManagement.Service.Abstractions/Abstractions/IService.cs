using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Service.Abstractions
{
    public interface IService<T>where T : class
    {
        public Task<int> AddAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(Func<T, bool> predicate);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetById(Func<T, bool> predicate);
    }
}
