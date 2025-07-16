using CustomerOrderManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CustomerOrderManagement.Repository.Database
{
    public class CustomerOrderDbContext : DbContext
    {
        public CustomerOrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerCategory> CustomersCategories { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
