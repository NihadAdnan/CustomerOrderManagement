using CustomerOrderManagement.Models;
using CustomerOrderManagement.Repository.Abstraction;
using EFCoreSamples.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<T> Entity
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }
        public async Task<int> AddAsync(T entity)
        {
            _dbContext.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Func<T, bool> predicate)
        {
            _dbContext.Remove(predicate);
            return await (_dbContext.SaveChangesAsync());
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await Entity.ToListAsync();
            return result;
        }

        public async Task<T> GetById(Func<T, bool> predicate)
        {
            var result = await Entity.FindAsync(predicate);
            return result;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
