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
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly CustomerOrderDbContext dbContext;
        public ProductRepository():base(new CustomerOrderDbContext())
        {

        }
    }
}
