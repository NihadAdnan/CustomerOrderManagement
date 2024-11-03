using CustomerOrderManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSamples.Database
{
    public class CustomerOrderDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerCategory> CustomersCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=IT-ANTOR\\MSSQLSERVER01; Database=CustomerOrderDB; Trusted_Connection=true; Integrated Security=true; TrustServerCertificate=true";

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.LogTo(c => Debug.WriteLine(c));
        }
    }
}
