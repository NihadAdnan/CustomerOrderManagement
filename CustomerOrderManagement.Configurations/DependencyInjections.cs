using CustomerOrderManagement.Repository.Abstraction;
using CustomerOrderManagement.Repository.Repositories;
using CustomerOrderManagement.Service;
using CustomerOrderManagement.Service.Abstractions;
using EFCoreSamples.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CustomerOrderManagement.Configurations
{
    public static class DependencyInjections
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<CustomerOrderDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}

