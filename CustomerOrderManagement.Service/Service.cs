using CustomerOrderManagement.Models;
using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Service
{
    public abstract class Service<T> : IService<T> where T : class,IEntity
    {
        private readonly IRepository<T> _repository;  
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<int> AddAsync(T entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<int> DeleteAsync(T entity)
        {
           return _repository.DeleteAsync(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetById(predicate);
        }

        public Task<int> UpdateAsync(T entity)
        {
            return (_repository.UpdateAsync(entity));   
        }
    }
}
