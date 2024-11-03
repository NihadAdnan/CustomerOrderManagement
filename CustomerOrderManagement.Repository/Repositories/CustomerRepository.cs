using CustomerOrderManagement.Models;
using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstraction;
using EFCoreSamples.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Repository.Repositories
{
    public class CustomerRepository:Repository<Customer>, ICustomerRepository
    {
        private readonly CustomerOrderDbContext _context;

        public CustomerRepository(CustomerOrderDbContext context):base(context)
        {
            _context = context;
        }
    }
}
