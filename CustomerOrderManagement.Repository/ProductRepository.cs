using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagement.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DbContext _dbContext;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
