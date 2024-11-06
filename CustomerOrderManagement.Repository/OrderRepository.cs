using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagement.Repository
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        private readonly DbContext _dbContext;
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
