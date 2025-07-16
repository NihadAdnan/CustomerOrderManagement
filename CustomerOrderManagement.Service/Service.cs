﻿using CustomerOrderManagement.Models;
using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service.Abstractions;
using System.Linq.Expressions;

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

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }
        public Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetById(predicate);
        }

        public Task<int> UpdateAsync(T entity)
        {
            return (_repository.UpdateAsync(entity));   
        }

        Task<IEnumerable<T>> IService<T>.GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
