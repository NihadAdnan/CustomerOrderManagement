using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstraction;
using CustomerOrderManagement.Repository.Repositories;
using CustomerOrderManagement.Service.Abstractions;

namespace CustomerOrderManagement.Service
{
    public class ProductService:Service<Product>,IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService():base(new ProductRepository())
        {
            _repository = new ProductRepository();
        }
    }
}
