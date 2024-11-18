using CustomerOrderManagement.Models;
using CustomerOrderManagement.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerOrderManagement.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
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

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            return await (_dbContext.SaveChangesAsync());
        }

        public IQueryable<T> GetAll()
        {
            var result = Entity.AsQueryable();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            var result = await Entity.FirstOrDefaultAsync(predicate);
            return result;
        }
        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
