using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagement.Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly DbContext _context;

        public CustomerRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
