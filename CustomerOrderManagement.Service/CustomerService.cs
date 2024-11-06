using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service.Abstractions;

namespace CustomerOrderManagement.Service
{
    public class CustomerService : Service<Customer>,ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
