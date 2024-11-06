using CustomerOrderManagement.Repository;
using CustomerOrderManagement.Repository.Abstractions;
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
            services.AddScoped<DbContext,CustomerOrderDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}

