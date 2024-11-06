using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository;
using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service.Abstractions;

namespace CustomerOrderManagement.Service
{
    public class ProductService:Service<Product>,IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository):base(repository)
        {
            _repository = repository;
        }
    }
}
